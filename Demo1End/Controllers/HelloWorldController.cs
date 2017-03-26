namespace Microsoft.Examples.Controllers
{
    using AspNetCore.Mvc.Routing;
    using AspNetCore.Routing;
    using Extensions.DependencyInjection;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class HelloWorldController : Controller
    {
        // GET api/helloworld
        [HttpGet]
        public IActionResult Get() => Ok(new { Controller = GetType().Name });

        // GET api/helloworld/{id}
        [HttpGet("{id:int}", Name = "GetMessageById")]
        public IActionResult Get(int id) => Ok(new { Controller = GetType().Name, Id = id });

        // POST api/helloworld
        [HttpPost]
        public IActionResult Post() => CreatedAtRoute("GetMessageById", new { id = 42 }, null);
    }
}