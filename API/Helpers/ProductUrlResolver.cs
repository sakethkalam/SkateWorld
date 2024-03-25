using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
       private readonly IConfiguration _Config;
        public ProductUrlResolver(IConfiguration config)
        {
            _Config = config;

        }

        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if(!String.IsNullOrEmpty(source.PictureUrl))
            {
                return _Config["Apiurl"] + source.PictureUrl;
            }

            return null;
        }
    }
}