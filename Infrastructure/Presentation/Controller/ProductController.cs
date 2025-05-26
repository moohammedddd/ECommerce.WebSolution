using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObject.Product;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Controller
{
    [Route("api/[controller]")] //BaseUrl + api/Controller Name
    [ApiController]
    public class ProductController(IServicesManager _servicesManager) : ControllerBase
    {
        //Get All Products
        [HttpGet] //BaseUrl/api/Product
        public async Task <ActionResult<IEnumerable<ProductResponse>>> GetAllProduct([FromQuery]ProductQueryParmeters productQueryParmeters)
        {
            var products =  await _servicesManager.ProductServices.GetAllProductAsync(productQueryParmeters);
            return Ok(products);
        }
        //Get Products By Id 
        [HttpGet("{id}")]  
        public async Task<ProductResponse> GetProductById(int id)
        {
            var products = await _servicesManager.ProductServices.GetProductByIdAsync(id);
           
            return products;

        }

        //Get ProductBrands
        [HttpGet("brands")] //BaseUrl/api/Product/brands
        public async Task <ActionResult<IEnumerable<ProductResponse>>> GetAllBrands()
        {
            var brands = await _servicesManager.ProductServices.GetAllBrandsAsync();
            return Ok(brands);
        }

        //Get ProductType
        [HttpGet("types")] //BaseUrl/api/Product/brands
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetAllTypes()
        {
            var brands = await _servicesManager.ProductServices.GetAllTypesAsync();
            return Ok(brands);
        }


        [HttpGet("topthree")] //BaseUrl/api/Product/topthree
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetTopThreeExpensiveProducts()
        {
            var products = await _servicesManager.ProductServices.GetTopThreeExpensiveProductsAsync();
            return Ok(products);
        }


    }
}
