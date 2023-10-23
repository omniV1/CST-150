using System;

namespace Milestone_Fall2023
{
    /// <summary>
    /// Represents a tool with associated metadata, including quantity, description, manufacturing details, and cost.
    /// </summary>
    public class Tool
    {
        // Properties
        public int ItemIdNumber { get; set; }
        public string? ItemDescription { get; set; }
        public int ItemQuantity { get; set; }
        public DateTime ItemManufacturingDate { get; set; }
        public decimal ItemCost { get; set; }
        public int? CustomerID { get; set; }  // Nullable CustomerID

        // Constructor
        public Tool(int itemIdNumber, string? description, int quantity, DateTime manufacturingDate, decimal cost)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Description cannot be null, empty, or whitespace.", nameof(description));
            }
            if (quantity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity cannot be negative.");
            }
            if (cost < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(cost), "Cost cannot be negative.");
            }

            ItemIdNumber = itemIdNumber;
            ItemDescription = description;
            ItemQuantity = quantity;
            ItemManufacturingDate = manufacturingDate;
            ItemCost = cost;
        }

        // Other methods or members can be added here as needed.
    }
}
