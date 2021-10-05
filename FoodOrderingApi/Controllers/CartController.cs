using FoodOrderingApi.Models;
using FoodOrderingApi.Models.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodOrderingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {

        private IRepositoryWrapper _repoWrapper;
        private CartManager _cartManager;
        public CartController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
            _cartManager = new CartManager(repoWrapper);
        }

        // GET: api/<CartController>
        // returns the current cart ie the cart with no order assosiated
        [HttpGet]
        public Cart Get()
        {
            return _repoWrapper.Cart.FindByCondition(x => x.Order.Equals(null)).Single();
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public Cart Get(int id)
        {
            return _repoWrapper.Cart.FindByCondition(x => x.CartId.Equals(id)).Single();
        }

    }
}
