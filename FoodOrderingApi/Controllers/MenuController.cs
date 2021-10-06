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
    public class MenuController : ControllerBase
    {

        private IRepositoryWrapper _repoWrapper;
        public MenuController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        // GET: api/<MenuController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repoWrapper.MenuItem.GetAll());
        }

        // GET api/<MenuController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int? id)
        {
            if (id == null) return BadRequest();

            var menuItem = RetrieveMenuItem(id);

            if (menuItem == null) return NotFound();
            
            return Ok(menuItem);
        }

        // POST api/<MenuController>
        [HttpPost]
        public IActionResult Post([FromBody] MenuItem value)
        {
            _repoWrapper.MenuItem.Create(value);
            _repoWrapper.Save();

            return Ok();
        }

        // PUT api/<MenuController>/5
        [HttpPut()]
        public IActionResult Put([FromBody] MenuItem value)
        {
            if (value == null) return BadRequest();

            var menuItem = RetrieveMenuItem(value.MenuItemId);

            if (menuItem == null) return NotFound();

            _repoWrapper.MenuItem.Update(value);
            _repoWrapper.Save();
            return Ok();
        }

        // DELETE api/<MenuController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            if (id == null) return BadRequest();

            var menuItem = RetrieveMenuItem(id);

            if (menuItem == null) return NotFound();

            _repoWrapper.MenuItem.Delete(menuItem);
            _repoWrapper.Save();

            return Ok();
        }

        private MenuItem RetrieveMenuItem(int? itemId)
        {
            return _repoWrapper.MenuItem.FindByCondition(x => x.MenuItemId.Equals(itemId)).Single();
        }
    }
}
