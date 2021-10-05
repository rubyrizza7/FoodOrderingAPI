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
    public class SelectionController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;
        private CartManager _cartManager;
        public SelectionController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
            _cartManager = new CartManager(repoWrapper);
        }

        // GET: api/<SelectionController>
        [HttpGet]
        public IEnumerable<Selection> Get()
        {
            return _repoWrapper.Selection.GetAll();
        }

        // GET api/<SelectionController>/5
        [HttpGet("{cartId}/{menuItemId}")]
        public Selection Get(int cartId, int menuItemId)
        {
            return _repoWrapper.Selection.FindByCondition(x => x.MenuItemId.Equals(menuItemId) && x.CartId.Equals(cartId)).Single();
        }

        // POST api/<SelectionController>
        [HttpPost]
        // Add to cart button
        public void Post([FromBody] Selection value)
        {
            _repoWrapper.Selection.Create(value);
        }

        // PUT api/<SelectionController>/5
        // change quantity
        [HttpPut("{cartId}/{menuItemId}")]
        public void Put(int cartId, int menuItemId, [FromBody] int value)
        {
            var currentSelection = Get(cartId, menuItemId);
            _cartManager.UpdateSelectionQty(currentSelection, value);
        }

        // DELETE api/<SelectionController>/5
        // Not implemented
        [HttpDelete("{cartId}/{menuItemId}")]
        public void Delete(int cartId, int menuItemId)
        {
            _repoWrapper.Selection.Delete(Get(cartId, menuItemId));
        }
    }
}
