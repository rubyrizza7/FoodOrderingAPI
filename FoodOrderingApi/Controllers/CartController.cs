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
        
        public CartController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        // GET: api/<CartController>
        // returns the current cart ie the cart with no order assosiated
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repoWrapper.Cart.GetAll());
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int? id)
        {
            if (id == null) return BadRequest();

            var cart = _repoWrapper.Cart.FindByCondition(x => x.CartId.Equals(id)).Single();

            if (cart == null)
            {
                return NotFound();
            }
            else 
            {
                return Ok(cart);
            }
            
        }

    }
}
