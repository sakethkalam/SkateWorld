using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductInterface
    {
        Task<Product> GetProductByIdAsync(int id);
       Task<IReadOnlyList<Product>> GetProductAsync();
       Task <IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
        Task <IReadOnlyList<ProductType>> GetProductTypesAsync();
    }
}