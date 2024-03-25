using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductInterface
    {
        private readonly StoreDbContext _dbContext;

        public ProductRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyList<Product>> GetProductAsync()
        {
            return await _dbContext.Products
            .Include(p=>p.ProductBrand)
            .Include(p=>p.ProductType)
            .ToListAsync();
            
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _dbContext.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _dbContext.Products
            .Include(p=>p.ProductBrand)
            .Include(p=>p.ProductType)
            .FirstOrDefaultAsync(p=>p.Id == id);
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _dbContext.ProductTypes.ToListAsync();
        }
    }
}