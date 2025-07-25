using TF_Net_IOT_DemoEntityFramework.DAL.Entities;

namespace TF_Net_IOT_DemoEntityFramework.API.Dtos.Products
{
    public class ProductIndexDto
    {
        public int Id { get; set; }
        public string Designation { get; set; } = null!;
        public int Price { get; set; }
        public int AlcoholLevel { get; set; }
        public int CurrentStock { get; set; }
    }
}
