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
    public class SelectionController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;
        private ICartManager _cartManager;
        public SelectionController(IRepositoryWrapper repoWrapper, ICartManager cartManager)
        {
            _repoWrapper = repoWrapper;
            _cartManager = cartManager;
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
        public void Post([FromBody] NewSelection value)
        {
            _cartManager.NewSelection(value);
        }

        // PUT api/<SelectionController>/5
        // change quantity
        [HttpPut("{cartId}/{menuItemId}/{changeInQty}")]
        public void Put(int cartId, int menuItemId, int changeInQty)
        {
            var currentSelection = Get(cartId, menuItemId);
            _cartManager.UpdateSelectionQty(currentSelection, changeInQty);
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
