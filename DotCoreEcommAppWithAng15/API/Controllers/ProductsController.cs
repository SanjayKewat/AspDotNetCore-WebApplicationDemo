using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using System.Reflection.Metadata.Ecma335; //ControllerBase come from this namespace

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

        public ProductsController(IGenericRepository<Product> productsRepo,
        IGenericRepository<ProductBrand> productBandRepo,
        IGenericRepository<ProductType> productTypeRepo
        )
        {
            _productsRepo = productsRepo;
            _productBrandRepo = productBandRepo;
            _productType = productTypeRepo;

        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            //Non-Generic pattern
            // var products = await _productRepository.GetProductsAsync();
            var products = await _productsRepo.ListAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            // var product = await _productRepository.GetProductByIdAsync(id);
            var product = await _productsRepo.GetByIdAsync(id);
            return Ok(product);
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