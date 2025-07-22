namespace TF_Net_IOT_DemoEntityFramework.DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Designation { get; set; } = null!;
        public int Price { get; set; }
        public int AlcoholLevel { get; set; }
        public string? Description { get; set; }
        public Stock? Stock { get; set; }
        public List<StockMovement> StockMovements { get; set; } = new List<StockMovement>();
        public List<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
    }
}
