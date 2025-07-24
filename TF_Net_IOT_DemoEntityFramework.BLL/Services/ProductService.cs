using TF_Net_IOT_DemoEntityFramework.DAL.Entities;
using TF_Net_IOT_DemoEntityFramework.DAL.Repositories;

namespace TF_Net_IOT_DemoEntityFramework.BLL.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _productRepository.GetProducts();
        }

        public async Task<Product> Insert(Product p)
        {
            return await _productRepository.Insert(p);
        }
    }
}
