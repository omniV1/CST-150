using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
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
namespace Milestone_Fall2023
{
    public partial class frmIntro : Form
    {

        /// Store the selected file path.

        private string inventoryFilePath = @"C:\Users\Owenl\source\repos\NewRepo\CST-150-af08709785acb292f0223b15d4961c1daeb4852b\Milestone_Fall2023\Milestone_Fall2023\bin\Debug\net7.0-windows\Inventory.txt";


        /// List to store tools after importing from file.

        private List<Tool> tools = new List<Tool>();

        //initializes tool tips 
        private ToolTip toolTip = new ToolTip();


        /// Initializes a new instance of the <see cref="frmIntro"/> class.

        public frmIntro()
        {
            InitializeComponent();
            btnContinueToCurrentInventory.Visible = false;
            InitializeToolTips();
        }
        /// <summary>
        /// Creates tooltips for the controls.
        /// </summary>
        private void InitializeToolTips()
        {
            ToolTip toolTip = new ToolTip();

            toolTip.SetToolTip(btnImportFile, "Click to import tools from a file.");
            toolTip.SetToolTip(btnContinueToCurrentInventory, "Click to continue to the Current Inventory form.");
        }
        /// <summary>
        /// Handles the Click event of the btnContinueToFrmCurrentInventory.
        /// Creates and shows the frmCurrentInventory form.
        /// </summary>
        private void BtnContinueToFrmCurrentInventory_Click(object sender, EventArgs e)
        {
            // Create and show the frmCurrentInventory form, passing the inventoryFilePath to it.
            frmCurrentInventory inventoryForm = new frmCurrentInventory(inventoryFilePath);
            inventoryForm.Show();

            // Hide the frmIntro form.
            this.Hide();
        }

        /// <summary>
        /// Handles the Click event of the btnImportFile. Imports tools from a selected file.
        /// </summary>
        private void BtnImportFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + @"Data\";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                inventoryFilePath = openFileDialog.FileName;
                if (File.Exists(inventoryFilePath))
                {
                    tools.Clear();
                    string[] lines = File.ReadAllLines(inventoryFilePath);
                    foreach (string line in lines)
                    {
                        var parts = line.Split(',');

                        if (parts.Length == 5)
                        {
                            try
                            {
                                int itemIdNumber = int.Parse(parts[0].Trim());
                                string itemDescription = parts[1].Trim();
                                int itemQuantity = int.Parse(parts[2].Trim());
                                DateTime itemManufacturingDate = DateTime.ParseExact(parts[3].Trim(), "M/d/yyyy", CultureInfo.InvariantCulture);
                                decimal itemCost = decimal.Parse(parts[4].Trim());

                                Tool tool = new Tool(itemIdNumber, itemDescription, itemQuantity, itemManufacturingDate, itemCost);
                                tools.Add(tool);
                            }
                            catch (FormatException fe)
                            {
                                MessageBox.Show($"Format error while processing the line '{line}': {fe.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            catch (OverflowException oe)
                            {
                                MessageBox.Show($"Overflow error while processing the line '{line}': {oe.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"An unexpected error occurred while processing the line '{line}': {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Line in incorrect format: {line}", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    tools.Sort((tool1, tool2) => tool1.ItemIdNumber.CompareTo(tool2.ItemIdNumber));

                    btnContinueToCurrentInventory.Visible = true;
                }
                else
                {
                    MessageBox.Show("Selected file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No file was selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}









