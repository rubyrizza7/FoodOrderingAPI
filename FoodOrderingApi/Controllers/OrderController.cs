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
    public class OrderController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;
        private ICartManager _cartManager;
        public OrderController(IRepositoryWrapper repoWrapper, ICartManager cartManager)
        {
            _repoWrapper = repoWrapper;
            _cartManager = cartManager;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IActionResult Get()
        {
            return  Ok(_repoWrapper.Order.GetAll());
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int? id)
        {
            if (id == null) return BadRequest();
            
            Order order = _repoWrapper.Order.FindByCondition(x => x.OrderId.Equals(id)).Single();

            if (order == null) return NotFound();

            return Ok(order);
        }

        // POST api/<OrderController>
        [HttpPost]
        public IActionResult Post([FromBody] OrderDTO newOrder)
        {
            
            return Ok(_cartManager.PlaceOrder(newOrder));
        }

    }
}
