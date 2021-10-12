﻿using FoodOrderingApi.Models;
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
        private ICartManager _cartManager;
        public NewCartController(IRepositoryWrapper repoWrapper, ICartManager cartManager)
        {
            _cartManager = cartManager;
        }

        // GET: api/<NewCartController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_cartManager.NewCart());
        }


    }
}
