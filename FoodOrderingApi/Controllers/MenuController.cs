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
        public IEnumerable<MenuItem> Get()
        {
            return _repoWrapper.MenuItem.GetAll();
        }

        // GET api/<MenuController>/5
        [HttpGet("{id}")]
        public MenuItem Get(int id)
        {
            return _repoWrapper.MenuItem.FindByCondition(x => x.MenuItemId.Equals(id)).Single();
        }

        // POST api/<MenuController>
        [HttpPost]
        public void Post([FromBody] MenuItem value)
        {
            _repoWrapper.MenuItem.Create(value);
            _repoWrapper.Save();
        }

        // PUT api/<MenuController>/5
        [HttpPut()]
        public void Put([FromBody] MenuItem value)
        {
            _repoWrapper.MenuItem.Update(value);
            _repoWrapper.Save();
        }

        // DELETE api/<MenuController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repoWrapper.MenuItem.Delete(Get(id));
            _repoWrapper.Save();
        }
    }
}
