using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using System.Reflection.Metadata.Ecma335;
using Core.Specifications;
using API.Dtos;
using AutoMapper; //ControllerBase come from this namespace

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        //This part is called dependency injections
        //here inject the service
        //use for non-generic repo
        // public IProductRepository _productRepository { get; set; }
        // public ProductsController(IProductRepository productRepository)
        // {
        //     this._productRepository = productRepository;

        // }

        //Generic Repos
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productType;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productsRepo,
        IGenericRepository<ProductBrand> productBandRepo,
        IGenericRepository<ProductType> productTypeRepo,
        IMapper mapper
        )
        {
            _productsRepo = productsRepo;
            _productBrandRepo = productBandRepo;
            _productType = productTypeRepo;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            //Non-Generic pattern
            // var products = await _productRepository.GetProductsAsync();
            // var products = await _productsRepo.ListAllAsync();


            //this will add include(add table Ref) property on Generic repository
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var products = await _productsRepo.ListAsync(spec);
            //return Ok(products);

            // return products.Select(product => new ProductToReturnDto
            // {
            //     Id = product.Id,
            //     Name = product.Name,
            //     Description = product.Description,
            //     PictureUrl = product.PictureUrl,
            //     Price = product.Price,
            //     ProductBrand = product.ProductBrand.Name,
            //     ProductType = product.ProductType.Name
            // }).ToList();

            return Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            //normal way to read data from context
            // var product = await _productRepository.GetProductByIdAsync(id);
            // return Ok(product);

            //this will add include(add table Ref) property on Generic repository
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productsRepo.GetEntityWithSpec(spec);
            // return new ProductToReturnDto
            // {
            //     Id = product.Id,
            //     Name = product.Name,
            //     Description = product.Description,
            //     PictureUrl = product.PictureUrl,
            //     Price = product.Price,
            //     ProductBrand = product.ProductBrand.Name,
            //     ProductType = product.ProductType.Name
            // };
            return _mapper.Map<Product, ProductToReturnDto>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            // var brands = await _productRepository.GetProductBrandsAsync();
            var brands = await _productBrandRepo.ListAllAsync();
            return Ok(brands);
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            // var productType = await _productRepository.GetProductTypesAsync();

            var productType = await _productType.ListAllAsync();
            return Ok(productType);
        }

        [HttpDelete("{id}")]
        public string DeleteProduct(int id)
        {
            return "product deleted";
        }
    }
}