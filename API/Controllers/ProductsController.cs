using System.Runtime.CompilerServices;
using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
       
        private readonly IGenericRepositry<Product> _ProductsRepo;
        private readonly IGenericRepositry<ProductBrand> _ProductsBrandRepo;
        private readonly IGenericRepositry<ProductType> _ProductTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepositry<Product> ProductsRepo,IGenericRepositry<ProductBrand> ProductsBrandRepo,
        IGenericRepositry<ProductType> ProductTypeRepo,IMapper mapper)
        {
            _mapper = mapper;
            _ProductTypeRepo = ProductTypeRepo;
            _ProductsBrandRepo = ProductsBrandRepo;
            _ProductsRepo = ProductsRepo;
        }  
            
        
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts(string sort)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(sort);
            var products = await _ProductsRepo.ListAsync(spec);
            
            return Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _ProductsRepo.GetEntitywithSpec(spec);

            if(id == null)
            {
                return NotFound(new ApiResponses(404));
            }
             
             return _mapper.Map<Product, ProductToReturnDto>(product);
        }

        [HttpGet("Brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _ProductsBrandRepo.ListAllAsync());
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _ProductTypeRepo.ListAllAsync());
        }
    }
}