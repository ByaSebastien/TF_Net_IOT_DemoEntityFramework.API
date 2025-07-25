using TF_Net_IOT_DemoEntityFramework.API.Dtos.Products;
using TF_Net_IOT_DemoEntityFramework.DAL.Entities;

namespace TF_Net_IOT_DemoEntityFramework.API.Mappers
{
    public static class ProductMapper
    {
        public static ProductIndexDto ToProductIndex(this Product product)
        {
            return new ProductIndexDto
            {
                Id = product.Id,
                Designation = product.Designation,
                Price = product.Price,
                AlcoholLevel = product.AlcoholLevel,
                CurrentStock = product.Stock is null ? 0 : product.Stock.CurrentQuantity
            };
        }

        public static ProductDetailDto ToProductDetail(this Product product)
        {
            return new ProductDetailDto
            {
                Id = product.Id,
                Designation = product.Designation,
                Price = product.Price,
                AlcoholLevel = product.AlcoholLevel,
                Description = product.Description,
            };
        }

        public static Product ToProduct(this ProductFormDto form)
        {
            return new Product
            {
                Designation = form.Designation,
                Price = form.Price,
                Description = form.Description,
                AlcoholLevel = form.AlcoholLevel,
            };
        }
    }
}
