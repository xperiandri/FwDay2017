﻿namespace Microsoft.Examples.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route( "api/[controller]" )]
    public class ValuesController : Controller
    {
        // GET api/values?api-version=1.0
        [HttpGet]
        public string Get() => $"Controller = {GetType().Name}";
    }
}