using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Web.Controllers
{
    [Route("api/[controller]")] //BaseUrl + api/Controller Name
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("{id:int}")]
        public ActionResult<Product> GetById(int id) //BaseUrl + api/Controller Name?id
        {
            return new Product
            {
                Id = id,
                Name = "Product " + id
            };
        }

        #region Notes
        // it is the same method of the method GetById it make Error
        [HttpGet]
        public ActionResult<Product> GetAll() //BaseUrl + api/Controller Name?id
        {
            return new Product
            {
                Id = 5
               
            };
        }
        #endregion

        [HttpPost]
        public ActionResult<Product> Add(Product product) //BaseUrl + api/Controller Name
        {
            return new Product
            {
                Id = product.Id,
                Name = product.Name
            };
        }
        [HttpPut]
        public ActionResult<Product> Update(Product product) //BaseUrl + api/Controller Name
        {
            return new Product
            {
                Id = product.Id,
                Name = product.Name
            };
        }

        [HttpDelete]
        public ActionResult<Product> Delete(Product product) //BaseUrl + api/Controller Name
        {
            return new Product
            {
                Id = product.Id,
                Name = product.Name
            };
        }
        public class Product
        {
            public int Id { get; set; }

            [Required]
            public string Name { get; set; }

        }

    }
}