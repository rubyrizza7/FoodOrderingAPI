using FoodOrderingApi.Models;
using FoodOrderingApi.Models.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewCartController : ControllerBase
    {
        private readonly ICartManager _cartManager;
        private readonly IRepositoryWrapper _repoWrapper;

        public NewCartController(IRepositoryWrapper repoWrapper, ICartManager cartManager)
        {
            _cartManager = cartManager;
            _repoWrapper = repoWrapper;
        }

        // GET: api/<NewCartController>
        [HttpGet]
        public IActionResult Get()
        {
            Cart newCart = _cartManager.NewCart();

            // return new state of cart
            return Ok(_repoWrapper.Cart.FindByCondition(x => x.CartId.Equals(newCart.CartId)).Single());
        }


    }
}
