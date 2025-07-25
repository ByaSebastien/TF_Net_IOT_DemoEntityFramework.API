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

        public async Task<Product> GetProduct(int id)
        {
            Product? product = await _productRepository.GetProduct(id);
            if (product == null) throw new Exception($"Product with id : {id} not found");
            return product;
        }

        public async Task<Product> Insert(Product p)
        {
            if (await _productRepository.ExistByDesignation(p.Designation))
            {
                throw new Exception($"Product with designation : {p.Designation} already exist");
            }
            return await _productRepository.Insert(p);
        }

        public async Task<Product> Update(int id, Product product)
        {
            Product? existing = await _productRepository.GetProduct(id);
            if (existing == null)
            {
                throw new Exception("Product not found");
            }
            if(product.Designation != existing.Designation && await _productRepository.ExistByDesignation(product.Designation))
            {
                throw new Exception($"Product with designation : {product.Designation} already exist");
            }
            existing.Designation = product.Designation;
            existing.Price = product.Price;
            existing.AlcoholLevel = product.Price;
            existing.Description = product.Description;
            return await _productRepository.Update(existing);
        }

        public async Task<Product> Delete(int id)
        {
            Product? product = await _productRepository.GetProduct(id);
            if (product == null) throw new Exception($"Product with id : {id} not found");
            Product deleted = await _productRepository.Delete(product);
            return deleted;
        }
    }
}
