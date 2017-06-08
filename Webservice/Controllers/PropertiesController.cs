﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSProperty4U;
using WebSProperty4U.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Webservice.Controllers
{
    [Route("api/[controller]")]
    public class PropertiesController : Controller
    {
        private DatabaseContext _ctx;
        public PropertiesController(DatabaseContext ctx)
        {
            _ctx = ctx;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Properties> Get()
        {
            return _ctx.Property;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}