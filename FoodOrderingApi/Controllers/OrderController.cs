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
        public IEnumerable<Order> Get()
        {
            return  _repoWrapper.Order.GetAll();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return _repoWrapper.Order.FindByCondition(x => x.OrderId.Equals(id)).Single();
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] int cartId)
        {
            _cartManager.PlaceOrder(cartId);
        }

    }
}
