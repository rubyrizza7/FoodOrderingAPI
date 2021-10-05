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
        private CartManager _cartManager;
        public NewCartController(IRepositoryWrapper repoWrapper)
        {
            _cartManager = new CartManager(repoWrapper);
        }

        // GET: api/<NewCartController>
        [HttpGet]
        public Cart Get()
        {
            return _cartManager.NewCart();
        }


    }
}
