using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreDbContext dbContext)
        {
            if(!dbContext.ProductBrands.Any())
            {
                var brandsdata = File.ReadAllText("../Infrastructure/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsdata);
                dbContext.ProductBrands.AddRange(brands);
            }

            if(!dbContext.ProductTypes.Any())
            {
                var brandstypesdata = File.ReadAllText("../Infrastructure/SeedData/types.Json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(brandstypesdata);
                dbContext.ProductTypes.AddRange(types);
            }

            if(!dbContext.Products.Any())
            {
                var productsdata = File.ReadAllText("../Infrastructure/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsdata);
                dbContext.Products.AddRange(products);
            }

            if(dbContext.ChangeTracker.HasChanges()) await dbContext.SaveChangesAsync();
        }
    }
}