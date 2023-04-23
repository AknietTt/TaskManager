using Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Implements;
using Service.Interface;

namespace TaskManager.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController:ControllerBase {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService) {
            _managerService = managerService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll() {
            var res = await _managerService.GetAll();
            return Ok(res);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] ManagerDto managerDto) {
            if(await _managerService.Create(managerDto)) {
                return Ok(managerDto);
            }
            return BadRequest();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromBody] ManagerDto managerDto,int id) {
            var employee = await _managerService.GetById(id);
            if(employee == null) {
                return NotFound();
            }

            if(!await _managerService.Update(managerDto)) {
                return BadRequest(managerDto);
            }

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id) {
            var employee = await _managerService.GetById(id);
            if(employee == null) {
                return NotFound();
            }
            if(!await _managerService.Delete(employee)) {
                return BadRequest();
            }
            return Ok(employee);
        }
    }
}
