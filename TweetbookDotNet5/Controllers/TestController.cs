using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TweetbookDotNet5.Controllers
{
    public class TestController : ControllerBase
    {
        [HttpGet("api/user")]
        public IActionResult Get()
        {
            return Ok(new { name = "Galal" });
        }
    }
}
