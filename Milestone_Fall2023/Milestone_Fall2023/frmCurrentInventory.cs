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
    /// <summary>
    /// Initializes a new instance of the frmCurrentInventory form.
    /// </summary>
    /// <param name="inventoryFilePath">The path to the inventory file.</param>
    public partial class frmCurrentInventory : Form
    {
        private List<Tool> tools = new List<Tool>();
        private ToolTip toolTip = new ToolTip();
        private string inventoryFilePath;
        private int currentPage = 0;
        private int itemsPerPage = 13;

        public frmCurrentInventory(string inventoryFilePath)
        {
            InitializeComponent();
            this.inventoryFilePath = inventoryFilePath;
            InitializeInventory();
            InitializeToolTips();
            this.FormClosed += (s, args) => Application.Exit();
        }



        /// <summary>
        /// Initializes tooltips for various controls on the form.
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
        /// Initializes inventory by reading from the inventory file and updating the display.
        /// </summary>
        private void InitializeInventory()
        {
            if (File.Exists(inventoryFilePath))
            {
                ReadInventoryFromFile();
                UpdateInventoryDisplay();
                PopulateComboBoxWithTools(); // Ensure you call this method here to populate the combo box

            }
            else
            {
                MessageBox.Show("Inventory file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void SelectedItemIdNumber(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            // Check if comboBox is not null
            if (comboBox != null)
            {
                if (comboBox.SelectedItem is Tool selectedTool)
                {
                    // Increment the quantity of the selected tool
                    selectedTool.ItemQuantity++;

                    // Update the display or data structure as necessary
                    UpdateInventoryDisplay(); // Refresh the inventory display
                    DisplaySelectedToolDetails(selectedTool);// Display the details of the selected tool

                    // Clear the ComboBox selection
                    comboBox.DataSource = null;
                    comboBox.Items.Clear(); // If you have manually added items, clear them as well.

                    // Optionally, repopulate the ComboBox if needed
                    // PopulateComboBoxWithTools(); // Uncomment and create this method if needed
                }
                else
                {
                    // Clear the display or show a default message if nothing is selected
                    lblDisplayInventory.Text = "Please select a tool to see its details.";
                }
            }
            else
            {
                // The comboBox is null, which should not typically happen.
                // This is an unexpected situation, handle it accordingly.
                MessageBox.Show("An unexpected error occurred. The selection control is not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        /// <summary>
        /// Event handler for the Next button click.
        /// Advances to the next page of inventory items if not on the last page.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains no event data.</param>
        private void BtnNext_Click(object sender, EventArgs e)
        {
           

            if (currentPage < (tools.Count - 1) / itemsPerPage)
            {
                currentPage++;
                UpdateInventoryDisplay();
            }
           

        }


        ///<summary>
        /// Event handler for the Previous button click.
        /// Goes back to the previous page of inventory items if not on the first page.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains no event data.</param>
        private void BtnPrevious_Click(object sender, EventArgs e)
        {
         

            if (currentPage > 0)
            {
                currentPage--;
                UpdateInventoryDisplay();
            }
            

        }


        /// <summary>
        /// Event handler for the Search button click.
        /// Initiates a search within the inventory.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains no event data.</param>
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchInventory();
        }


        /// <summary>
        /// Event handler for the Save Inventory button click.
        /// Saves the current state of the inventory to the file.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains no event data.</param>
        private void BtnSaveInventory_OnClick(object sender, EventArgs e)
        {
            SaveInventoryToFile();
        }


        /// <summary>
        /// Event handler for the Sort By ID Highest to Lowest button click.
        /// Sorts the inventory items by ID in descending order.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains no event data.</param>
        private void BtnSortByIDHighestToLowest_OnClick(object sender, EventArgs e)
        {
            SortInventoryByIDDescending();
            UpdateInventoryDisplay();
        }
        /// <summary>
        /// Sorts the inventory by item ID in descending order and updates the display.
        /// </summary>
        private void SortInventoryByIDDescending()
        {
            tools = tools.OrderByDescending(t => t.ItemIdNumber).ToList();
        }
        /// <summary>
        /// Sorts the inventory by cost in descending order and updates the display.
        /// </summary>
        private void BtnSortByCostHighestToLowest_OnClick(object sender, EventArgs e)
        {
            SortInventoryByCostDescending();
            UpdateInventoryDisplay();
        }

        private void SortInventoryByCostDescending()
        {
            tools = tools.OrderByDescending(t => t.ItemCost).ToList();
        }

        /// <summary>
        /// Reads the inventory from the file specified by the inventoryFilePath.
        /// </summary>
        private void ReadInventoryFromFile()
        {
            tools.Clear();
            var lines = File.ReadAllLines(inventoryFilePath);

            foreach (var line in lines)
            {
                try
                {
                    var parts = line.Split(',');
                    int id = int.Parse(parts[0].Trim());
                    string description = parts[1].Trim();
                    int quantity = int.Parse(parts[2].Trim());
                    DateTime manufacturingDate = DateTime.Parse(parts[3].Trim());
                    decimal cost = decimal.Parse(parts[4].Trim());
                    int? customerID = parts.Length > 5 ? int.Parse(parts[5].Trim()) : (int?)null;

                    Tool tool = new Tool(id, description, quantity, manufacturingDate, cost);
                    tools.Add(tool);
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

            tools = tools.OrderBy(t => t.ItemIdNumber).ToList();
        }
        /// <summary>
        /// Populates the combo box with tools read from the inventory.
        /// </summary
        private void PopulateComboBoxWithTools()
        {
            // We check if the tools list is already populated to avoid reading the file again.
            if (tools == null || !tools.Any())
            {
                // Define the path to your text file
                string inventoryFilePath = @"C:\Users\Owenl\source\repos\NewRepo\CST-150-af08709785acb292f0223b15d4961c1daeb4852b\Milestone_Fall2023\Milestone_Fall2023\bin\Debug\net7.0-windows\Inventory.txt";

                // Check if the file exists before trying to read it
                if (File.Exists(inventoryFilePath))
                {
                    // Read all lines from the text file
                    string[] lines = File.ReadAllLines(inventoryFilePath);

                    // Initialize the tools list if it's null
                    tools = new List<Tool>();

                    // Process each line and create a Tool object
                    foreach (var line in lines)
                    {
                        // Split the line into parts using the delimiter (e.g., a comma)
                        string[] parts = line.Split(',');

                        // Make sure to have the correct number of parts and they are not empty
                        if (parts.Length >= 5)
                        {
                            // Parse each part to the expected type
                            int itemIdNumber = Convert.ToInt32(parts[0]);
                            string itemDescription = parts[1];
                            int itemQuantity = Convert.ToInt32(parts[2]);
                            DateTime itemManufactureDate = DateTime.Parse(parts[3]);
                            decimal itemCost = Convert.ToDecimal(parts[4]);
                            int? customerId = parts.Length > 5 && !string.IsNullOrWhiteSpace(parts[5]) ? Convert.ToInt32(parts[5]) : (int?)null;

                            // Create a new Tool object and initialize its properties
                            Tool tool = new Tool(itemIdNumber, itemDescription, itemQuantity, itemManufactureDate, itemCost); // Assuming the constructor accepts customerId if it's present

                            // Add the Tool object to the list
                            tools.Add(tool);
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"File not found: {inventoryFilePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Set the DataSource property of the ComboBox to your list of tools
            cmbSelectItemId.DataSource = null; // Resetting the DataSource to ensure the ComboBox refreshes
            cmbSelectItemId.DataSource = tools;

            // Assuming you want to display the 'ItemDescription' and use 'ItemIdNumber' as the value.
            cmbSelectItemId.DisplayMember = "ItemIdNumber";
            cmbSelectItemId.ValueMember = "ItemDescription";
        }


        /// <summary>
        /// Updates the display label with the current page of inventory items.
        /// </summary>
        private void UpdateInventoryDisplay()
        {
            int startIndex = currentPage * itemsPerPage;
            int endIndex = Math.Min(startIndex + itemsPerPage, tools.Count);
            var displayedTools = tools.Skip(startIndex).Take(itemsPerPage);
            lblDisplayInventory.Text = string.Join(Environment.NewLine, displayedTools.Select(t =>
                $"{t.ItemIdNumber} - {t.ItemDescription} ({t.ItemQuantity}) - Built: {t.ItemManufacturingDate.ToShortDateString()} - Cost: ${t.ItemCost}"
                + (t.CustomerID.HasValue ? $" - CustomerID: {t.CustomerID}" : string.Empty)));
            lblDisplayInventory.Visible = true;
        }

        private void SearchInventory()
        {
            var searchTerm = txtSearch.Text.Trim();
            var searchResults = tools.Where(t => t.ItemDescription.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
            lblDisplayInventory.Text = string.Join(Environment.NewLine, searchResults.Select(t =>
                $"{t.ItemIdNumber} - {t.ItemDescription} - {t.ItemQuantity} - {t.ItemManufacturingDate.ToShortDateString()} - ${t.ItemCost}"
                + (t.CustomerID.HasValue ? $" - CustomerID: {t.CustomerID}" : string.Empty)));
        }
        /// <summary>
        /// Saves the current inventory to the file.
        /// </summary>
        private void SaveInventoryToFile()
        {
            using (StreamWriter writer = new StreamWriter(inventoryFilePath, false))
            {
                foreach (var tool in tools)
                {
                    writer.WriteLine($"{tool.ItemIdNumber}, {tool.ItemDescription}, {tool.ItemQuantity}, {tool.ItemManufacturingDate.ToShortDateString()}, {tool.ItemCost}{(tool.CustomerID.HasValue ? $", {tool.CustomerID}" : "")}");
                }
            }
            MessageBox.Show("Inventory saved successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// Displays details of the selected tool in the inventory.
        /// </summary>
        /// <param name="tool">The tool to display details for.</param>
        private void DisplaySelectedToolDetails(Tool tool)
        {
            // Display the selected tool's details in lblDisplayInventory
            lblDisplayInventory.Text = $"ID: {tool.ItemIdNumber}\n" +
                                       $"Description: {tool.ItemDescription}\n" +
                                       $"Quantity: {tool.ItemQuantity}\n" +
                                       $"Built Date: {tool.ItemManufacturingDate.ToShortDateString()}\n" +
                                       $"Cost: ${tool.ItemCost}\n" +
                                       $"Customer ID: {(tool.CustomerID.HasValue ? tool.CustomerID.ToString() : "N/A")}";
        }

    }
}

