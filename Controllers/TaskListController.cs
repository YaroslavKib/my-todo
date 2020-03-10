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
    public class TaskListController : ControllerBase
    {
        private readonly Services.TaskListService _service;

        private string UserId = "dev_test_owner_id"; // for testing

        public TaskListController(Services.TaskListService taskListService)
        {
            _service = taskListService;
        }

        [HttpGet("")]
        public ActionResult Get()
        {
            return Ok(_service.GetByOwnerId(UserId));
        }

        [HttpGet("{id}")]
        public ActionResult GetById(long id)
        {
            return Ok(_service.GetById(id));
        }

        [HttpPost("")]
        public ActionResult Post(Models.TaskList taskList)
        {
            taskList.OwnerId = UserId;
            return Ok(_service.Add(taskList));
        }

        [HttpPut("{id}")]
        public ActionResult Put(long id, Models.TaskList taskList)
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
