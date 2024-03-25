using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using API.Dtos;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d =>d.ProductBrand,o=>o.MapFrom(s=>s.ProductBrand))
                .ForMember(d =>d.ProductType,o=>o.MapFrom(s =>s.ProductType))
                .ForMember(d => d.PictureUrl,o=> o.MapFrom<ProductUrlResolver>());
        }
    }
}