using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfulApi_PostgreSql.Models;
using RestfulApi_PostgreSql.Data;
using RestfulApi_PostgreSql.Dto;
using Microsoft.EntityFrameworkCore;


namespace RestfulApi_PostgreSql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getAllEmployeesAsync()
        {
            var employee = await _context.Employee.ToListAsync();
            return Ok(employee);
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> addEmployeeAsync(AddEmployeeDto addEmployeeDto)
        {
            var employee = new Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary,
            };
            await _context.AddAsync(employee);
            await _context.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> getEmployeeByIdAsync(Guid id) {
            var employee = await _context.Employee.FindAsync(id);
            if (employee is null) { 
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> editEmployeeByIdAsync(Guid id, EditEmployeeDto editEmployeeDto) {
            var employee = await _context.Employee.FindAsync(id);
            if (employee is null)
            {
                return NotFound();
            }
            employee.Name = editEmployeeDto.Name;
            employee.Email = editEmployeeDto.Email;
            employee.Phone = editEmployeeDto.Phone;
            employee.Salary = editEmployeeDto.Salary;
            await _context.SaveChangesAsync();
            return Ok(employee);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> deleteEmployeeByIdAsync(Guid id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee is null) {
                return NotFound();
            }
            _context.Remove(employee);
            await _context.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpDelete]
        [Route("All")]
        public async Task<IActionResult> deleteEmployessAsync() {
            var employee = await _context.Employee.ToListAsync();
            if (employee is null)
            {
                return NotFound();
            }
            _context.RemoveRange(employee);
            await _context.SaveChangesAsync();
            return Ok(employee);
        }
    }

}
