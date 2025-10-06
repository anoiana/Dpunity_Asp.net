using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Application.Interfacaes;
using EmployeeManagement.Application.Services;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Application.Dtos.Request;
using Microsoft.AspNetCore.Authorization;

namespace ProductMana.Controller.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService e)
        {
            _employeeService = e;
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetEmployeeById(Guid id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var employee = await _employeeService.AddEmployeeAsync(addEmployeeDto);
            return Ok(employee);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditEmployee(Guid id,EditEmployeeDtocs editEmployeeDtocs)
        {
            await _employeeService.UpdateAsync(editEmployeeDtocs, id);
            return Ok();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return Ok();
        }
    }
}
