using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(string sort)
        {
            AddIncude(x=>x.ProductType);
            AddIncude(x=>x.ProductBrand);
            AddOrderBy(x=>x.Name);
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddIncude(x=>x.ProductType);
            AddIncude(x=>x.ProductBrand);
        }
    }
}