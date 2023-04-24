using Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Implements;
using Service.Interface;

namespace TaskManager.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController:ControllerBase {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService) {
            _taskService = taskService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll() {
            var res = await _taskService.GetAll();
            return Ok(res);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] TaskDto taskDto) {
            if(await _taskService.Create(taskDto)) {
                return Ok(taskDto);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id) {
            var task = await _taskService.GetById(id);
            if(task == null) {
                return NotFound();
            }
            if(!await _taskService.Delete(task)) {
                return BadRequest();
            }
            return Ok(task);
        }
    }
}
