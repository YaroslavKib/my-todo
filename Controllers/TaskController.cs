using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace my_todo.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;

        public TaskController(ILogger<TaskController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public ActionResult Get()
        {
            return Problem("Not implemented");
        }

        [HttpGet("{id}")]
        public ActionResult GetById(long id)
        {
            return Problem("Not implemented");
        }

        [HttpPut("")]
        public ActionResult Put(string content)
        {
            return Problem("Not implemented");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteById(long id)
        {
            return Problem("Not implemented");
        }
    }
}
