// Anita Martin
// amartin98@cnm.edu
// Title: DBDemo- In class assignment

// InventoryItem.cs

namespace DBDemoInClass
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Location { get; set; }
        public double Weight { get; set; }
        public decimal Cost { get; set; }
        public string Remarks { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} Located at {Location}";
        }

    }
}
