using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_Net_IOT_DemoEntityFramework.DAL.Entities;

namespace TF_Net_IOT_DemoEntityFramework.DAL.Repositories
{
    public class ProductRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Product> _products;

        public ProductRepository(DbContext context)
        {
            _context = context;
            _products = _context.Set<Product>();
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _products
                .ToListAsync();
        }

        public async Task<Product?> GetProduct(int id)
        {
            return await _products
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> Insert(Product product)
        {
            await _products.AddAsync(product);
            _context.SaveChanges();
            return product;
        }
    }
}
