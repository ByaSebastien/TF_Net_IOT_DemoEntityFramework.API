namespace TF_Net_IOT_DemoEntityFramework.DAL.Entities
{
    public class Stock
    {
        public int Id { get; set; }
        public int CurrentQuantity { get; set; }
        public int? LimitQuantity { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
