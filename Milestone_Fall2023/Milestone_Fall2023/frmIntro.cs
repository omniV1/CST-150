using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Milestone_Fall2023
{
    public partial class frmIntro : Form
    {

        /// Store the selected file path.

        private string inventoryFilePath = "";


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
                inventoryFilePath = openFileDialog.FileName; // This line sets the inventoryFilePath

                string[] lines = File.ReadAllLines(openFileDialog.FileName);
                foreach (string line in lines)
                {
                    {
                        var parts = line.Split(',');
                        if (parts.Length >= 5) // Ensure there are enough parts to match the expected format
                        {
                            try
                            {
                                int itemIdNumber = int.Parse(parts[0].Trim());
                                string itemDescription = parts[1].Trim();
                                int itemQuantity = int.Parse(parts[2].Trim());
                                DateTime itemManufacturingDate = DateTime.Parse(parts[3].Trim());
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
                    }
                    btnContinueToCurrentInventory.Visible = true; // Show the button to proceed to frmCurrentInventory
                }
            }
        }
    }
}
