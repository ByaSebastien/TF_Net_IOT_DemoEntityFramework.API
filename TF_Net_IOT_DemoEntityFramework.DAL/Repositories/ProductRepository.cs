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
                .Include(p => p.Stock)
                .ToListAsync();

            // Exemple de opération en chaine
            //return await _products
            //    .Include(p => p.Stock)
            //    .Include(p => p.OrderLines)
            //    .ThenInclude(ol => ol.Order)
            //    .Where(p => p.Stock!.CurrentQuantity > 0)
            //    .OrderBy(p => p.Designation)
            //    .ToListAsync();
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

        public async Task<Product> Update(Product product)
        {
            _products.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> Delete(Product product)
        {
            _products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> ExistByDesignation(string designation)
        {
            return await _products.AnyAsync(p => p.Designation == designation);
        }
    }
}
