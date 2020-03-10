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
        private readonly Services.TaskService _taskService;

        private string UserId = "dev_test_owner_id"; // for testing

        public TaskController(Services.TaskService taskSerivce)
        {
            _taskService = taskSerivce;
        }

        [HttpGet("")]
        public ActionResult Get()
        {
            return Ok(_taskService.GetByOwnerId(UserId));
        }

        [HttpGet("{id}")]
        public ActionResult GetById(long id)
        {
            return Ok(_taskService.GetByTaskId(id));
        }

        [HttpPost("")]
        public ActionResult Post(Models.Task task)
        {
            task.OwnerId = UserId;
            return Ok(_taskService.Add(task));
        }

        [HttpPut("{id}")]
        public ActionResult Put(long id, Models.Task task)
        {
            return Problem("Not implemented");
        }

        [HttpDelete("")]
        public ActionResult Delete()
        {
            return Ok(_taskService.DeleteAll(UserId));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteById(long id)
        {
            return Ok(_taskService.Delete(id, UserId));
        }
    }
}
