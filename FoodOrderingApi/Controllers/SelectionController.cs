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
        public IActionResult Get()
        {
            return Ok(_repoWrapper.Selection.GetAll());
        }

        // GET api/<SelectionController>/5
        [HttpGet("{cartId}/{menuItemId}")]
        public IActionResult Get(int? cartId, int? menuItemId)
        {
            if (cartId == null || menuItemId == null) return BadRequest();

            Selection selection = _repoWrapper.Selection.FindByCondition(x => x.MenuItemId.Equals(menuItemId) && x.CartId.Equals(cartId)).Single();

            if (selection == null) return NotFound();

            return Ok(selection);
        }

        // POST api/<SelectionController>
        [HttpPost]
        // Add to cart button
        public IActionResult Post([FromBody] SelectionDTO value)
        {
            return Ok(_cartManager.NewSelection(value));
        }

        // PUT api/<SelectionController>/5
        // change quantity
        [HttpPut("{cartId}/{menuItemId}/{changeInQty}")]
        public IActionResult Put(int? cartId, int? menuItemId, int? changeInQty)
        {
            if (cartId == null || menuItemId == null || changeInQty == null) return BadRequest();

            Selection selection = _repoWrapper.Selection.FindByCondition(x => x.MenuItemId.Equals(menuItemId) && x.CartId.Equals(cartId)).Single();

            if (selection == null) return NotFound();

            return Ok(_cartManager.UpdateSelectionQty(selection, changeInQty.GetValueOrDefault()));
        }

        // DELETE api/<SelectionController>/5
        // Not implemented
        [HttpDelete("{cartId}/{menuItemId}")]
        public IActionResult Delete(int? cartId, int? menuItemId)
        {
            if (cartId == null || menuItemId == null) return BadRequest();

            Selection selection = _repoWrapper.Selection.FindByCondition(x => x.MenuItemId.Equals(menuItemId) && x.CartId.Equals(cartId)).Single();

            if (selection == null) return NotFound();

            _repoWrapper.Selection.Delete(selection);

            return Ok();
        }
    }
}
