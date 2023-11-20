using System;

namespace Milestone_Fall2023
{
    /// <summary>
    /// Represents a tool with associated metadata, including quantity, description, manufacturing details, and cost.
    /// </summary>
    public class Tool
    {
        // Property for unique item identifier
        public int ItemIdNumber { get; set; }

        // Using a nullable string for ItemDescription
        public string? ItemDescription { get; set; }

        // Property for the quantity of items
        public int ItemQuantity { get; set; }

        // Property for the manufacturing date of the item
        public DateTime ItemManufacturingDate { get; set; }

        // Property for the price of the item
        public decimal ItemCost { get; set; }
 
        public int? CustomerID { get; set; }
       
        // Constructor for the Tool class
        public Tool(int itemIdNumber, string? itemDescription, int itemQuantity, DateTime itemManufacturingDate, decimal itemPrice)
        {
            ItemIdNumber = itemIdNumber;
            ItemDescription = itemDescription;
            ItemQuantity = itemQuantity;
            ItemManufacturingDate = itemManufacturingDate;
            ItemCost = itemPrice;
            
    }

        // Method to get a non-null item description
        public string GetSafeItemDescription()
        {
            // Return ItemDescription if not null, otherwise a default string
            return ItemDescription ?? "Default description";
        }

        // You may want to add additional methods that manipulate or present the data
        // For example, a method to format the manufacturing date

        public string GetFormattedManufacturingDate()
        {
            return ItemManufacturingDate.ToString("yyyy-MM-dd");
        }
        public decimal GetInventoryValue()
        {
            return ItemQuantity * ItemCost;
        }

        public class ToolInventory
        {
            // Collection of Tool objects
            public List<Tool> Tools { get; set; }

            public ToolInventory()
            {
                // Initialize the Tools list
                Tools = new List<Tool>();
            }
        
        }
    }
}
