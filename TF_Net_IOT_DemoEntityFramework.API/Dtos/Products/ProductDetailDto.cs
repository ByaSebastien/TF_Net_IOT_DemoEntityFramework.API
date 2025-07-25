﻿namespace TF_Net_IOT_DemoEntityFramework.API.Dtos.Products
{
    public class ProductDetailDto
    {
        public int Id { get; set; }
        public string Designation { get; set; } = null!;
        public int Price { get; set; }
        public int AlcoholLevel { get; set; }
        public string? Description { get; set; }
    }
}
