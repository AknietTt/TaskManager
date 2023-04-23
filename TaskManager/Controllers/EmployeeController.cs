using Domain.DTO;

using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace TaskManager.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController:ControllerBase {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService) {
            _employeeService = employeeService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll() { 
           var res = await _employeeService.GetAll();
           return Ok(res);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] EmployeeDto employeeDto) {
            if(await _employeeService.Create(employeeDto)) {
                return Ok(employeeDto);
            }
            return BadRequest();
        }
        
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromBody] EmployeeDto employeeDto, int id) {
            var employee = await _employeeService.GetById(id);
            if(employee == null){
                return NotFound();
            }

            if(!await _employeeService.Update(employeeDto)) {
                return BadRequest(employeeDto);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id) { 
            var employee = await _employeeService.GetById(id);
            if(employee == null) {
                return NotFound();
            } 
            if(!await _employeeService.Delete(employee)) {
                return BadRequest();
            }
            return Ok(employee);
        }
    }
}
