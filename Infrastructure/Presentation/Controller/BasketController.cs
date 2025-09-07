using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controller
{
    [Route("api/[controller]")] //BaseUrl + api/Controller Name
    [ApiController]

    public class BasketController(IServicesManager _servicesManager) : ControllerBase
    {
        //1) Get User Basket 
        [HttpGet]
        public async Task<ActionResult<BasketDto>> Get(string id)
        {
            var basket = await _servicesManager.BasketService.GetAsync(id);
            return Ok(basket);
        }



        //2) Update User Basket
        //2.1) Create Basket
        //2.2) Add Item To Basket
        //2.3) Remove Item From Basket
        //2.4) Update Item Quantity In Basket
        [HttpPost]
        public async Task<ActionResult<BasketDto>> Update(BasketDto basketDto)
        {
            var basket = await _servicesManager.BasketService.UpdateAsync(basketDto);
            return Ok(basket);
        }
        //3) Clear User Basket After Checkout => Empty Basket 
        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            await _servicesManager.BasketService.DeleteAsync(id);
            return NoContent();


        }
    }
}