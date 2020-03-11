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
        // private string UserId => User.Claims
        //    .Where(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)
        //    .Select(c => c.Value)
        //    .First();

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
            var result = _taskService.GetByTaskId(id);

            if (result == null)
                return NotFound();
            
            return Ok(result);
        }

        [HttpPost("")]
        public ActionResult Post(Models.Task task)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
            task.OwnerId = UserId;
            return Ok(_taskService.Add(task));
        }

        [HttpPut("{id}")]
        public ActionResult Put(long id, Models.Task task)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _taskService.Put(id, task);

            if (result == null)
                return NotFound();
            
            return Ok(result);
        }

        [HttpDelete("")]
        public ActionResult Delete()
        {
            return Ok(_taskService.DeleteAll(UserId));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteById(long id)
        {
            var result = _taskService.Delete(id, UserId);

            if (result == null)
                return NotFound();
            else
                return Ok(result);
        }
    }
}
