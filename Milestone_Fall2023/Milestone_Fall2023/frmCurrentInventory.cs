/*
 * Owen Lindsey
 * CST-150
 * Milestone2
 * 10/8/2023
 * This work was done by me and with the help of : 
 * GeeksforGeeks. (2023, September 27). C#: Encapsulation. GeeksforGeeks. https://www.geeksforgeeks.org/c-sharp-encapsulation/ 
 * BillWagner. (n.d.). Nullable reference types - C#. C# | Microsoft Learn. https://learn.microsoft.com/en-us/dotnet/csharp/nullable-references 
 * BillWagner. (n.d.-b). Properties in C# - C#. in C# - C# | Microsoft Learn. https://learn.microsoft.com/en-us/dotnet/csharp/properties 
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Milestone_Fall2023
{
    public partial class frmCurrentInventory : Form
    {
        private List<Tool> tools = new List<Tool>();
        private ToolTip toolTip = new ToolTip();
        private string inventoryFilePath;

        private int currentPage = 0; // Current page index
        private int itemsPerPage = 13; // Number of items to display per page

        /// <summary>
        /// Initializes a new instance of the <see cref="frmCurrentInventory"/> class.
        /// </summary>
        /// <param name="inventoryFilePath">The file path of the inventory.</param>
        public frmCurrentInventory(string inventoryFilePath)
        {
            InitializeComponent();
            this.inventoryFilePath = inventoryFilePath;

            // Load tools from the file
            InitializeInventory();

            // ToolTip initialization
            InitializeToolTips();

            // Ensure hidden forms close when exiting any of the forms
            this.FormClosed += (s, args) => Application.Exit();
        }

        /// <summary>
        /// Initializes tooltips for UI elements.
        /// </summary>
        private void InitializeToolTips()
        {
            toolTip.Active = true;

            toolTip.SetToolTip(btnSaveInventory, "Click to save the inventory to a file.");
            toolTip.SetToolTip(lblDisplayInventory, "Current inventory display.");

            toolTip.SetToolTip(btnSortByIDHighestToLowest, "Sort tools by ID in descending order.");
            toolTip.SetToolTip(btnSortByHighestCostToLowest, "Sort tools by cost in descending order.");

            toolTip.SetToolTip(btnSearch, "Click to search for the specific item.");
            toolTip.SetToolTip(txtSearch, "Enter a keyword to search for tools.");
        }

        /// <summary>
        /// Initializes the inventory by reading from a file.
        /// </summary>
        private void InitializeInventory()
        {
            if (File.Exists(inventoryFilePath))
            {
                // Read from the file and populate the tools list
                foreach (var line in File.ReadAllLines(inventoryFilePath))
                {
                    try
                    {
                        var parts = line.Split(',');
                        int id = int.Parse(parts[0].Trim());
                        string description = parts[1].Trim();
                        int quantity = int.Parse(parts[2].Trim());
                        DateTime manufacturingDate = DateTime.Parse(parts[3].Trim());
                        decimal cost = decimal.Parse(parts[4].Trim());

                        // If there's a customer ID, parse it. Else, it will be null.
                        int? customerID = parts.Length > 5 ? int.Parse(parts[5].Trim()) : (int?)null;

                        tools.Add(new Tool(id, description, quantity, manufacturingDate, cost));
                    }
                    catch (FormatException formatEx)
                    {
                        MessageBox.Show($"Data format error: {formatEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Automatically update the display after initializing
                UpdateInventoryDisplay();
            }
            else
            {
                // Handle the case when the file doesn't exist
                MessageBox.Show("Inventory file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        /// <summary>
        /// Event handler for sorting the inventory by ID in descending order.
        /// </summary>
        private void BtnSortByIDHighestToLowest_OnClick(object sender, EventArgs e)
        {
            tools = tools.OrderByDescending(t => t.ItemIdNumber).ToList();
            UpdateInventoryDisplay();
        }

        /// <summary>
        /// Event handler for sorting the inventory by cost in descending order.
        /// </summary>
        private void BtnSortByCostHighestToLowest_OnClick(object sender, EventArgs e)
        {
            tools = tools.OrderByDescending(t => t.ItemCost).ToList();
            UpdateInventoryDisplay();
        }

        /// <summary>
        /// Updates the lblDisplayInventory with the current tools list.
        /// </summary>
        private void UpdateInventoryDisplay()
        {
            int startIndex = currentPage * itemsPerPage;
            int endIndex = Math.Min(startIndex + itemsPerPage, tools.Count);

            var displayedTools = tools.Skip(startIndex).Take(itemsPerPage);

            lblDisplayInventory.Text = string.Join(Environment.NewLine, displayedTools.Select(t =>
                $"{t.ItemIdNumber} - {t.ItemDescription} ({t.ItemQuantity}) - Built: {t.ItemManufacturingDate.ToShortDateString()} - Cost: ${t.ItemCost}"
                + (t.CustomerID.HasValue ? $" - CustomerID: {t.CustomerID}" : string.Empty)
            ));

            lblDisplayInventory.Visible = true;
        }

        /// <summary>
        /// Event handler for the "Next" button click.
        /// </summary>
        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < (tools.Count - 1) / itemsPerPage)
            {
                currentPage++;
                UpdateInventoryDisplay();
            }
        }

        /// <summary>
        /// Event handler for the "Previous" button click.
        /// </summary>
        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 0)
            {
                currentPage--;
                UpdateInventoryDisplay();
            }
        }

        /// <summary>
        /// Event handler for the "Search" button click.
        /// Filters the tools list based on a keyword and updates the display.
        /// </summary>
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Please enter a keyword to search.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var filteredTools = tools.Where(t => t.ItemDescription.ToLower().Contains(keyword)).ToList();

            if (filteredTools.Count == 0)
            {
                lblDisplayInventory.Text = "No tools found for the given keyword.";
            }
            else
            {
                lblDisplayInventory.Text = string.Join(Environment.NewLine, filteredTools.Select(t =>
                    $"{t.ItemIdNumber} - {t.ItemDescription} ({t.ItemQuantity}) - Built: {t.ItemManufacturingDate.ToShortDateString()} - Cost: ${t.ItemCost}"
                    + (t.CustomerID.HasValue ? $" - CustomerID: {t.CustomerID}" : string.Empty)
                ));
            }

            lblDisplayInventory.Visible = true;
        }

        /// <summary>
        /// Event handler for the "Save Inventory" button click.
        /// Saves the current inventory to a text file.
        /// </summary>
        private void BtnSaveInventory_OnClick(object sender, EventArgs e)
        {
            try
            {
                SaveInventoryToFile();
                MessageBox.Show($"Inventory saved to {inventoryFilePath} successfully!", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the inventory: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Saves the current inventory to a text file.
        /// </summary>
        private void SaveInventoryToFile()
        {
            // Use the file path that's set for the inventory.
            List<string> lines = tools.Select(t =>
                $"{t.ItemIdNumber}, {t.ItemDescription}, {t.ItemQuantity}, {t.ItemManufacturingDate.ToShortDateString()}, {t.ItemCost}"
                + (t.CustomerID.HasValue ? $", {t.CustomerID}" : string.Empty)
            ).ToList();

            File.WriteAllLines(inventoryFilePath, lines);
        }
    }
}
