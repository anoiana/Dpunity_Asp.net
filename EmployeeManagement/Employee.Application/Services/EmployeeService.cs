using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Application.Interfacaes;
using EmployeeManagement.Application.Dtos.Response;
using EmployeeManagement.Application.Dtos.Request;

namespace EmployeeManagement.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeInterfaces;

        public EmployeeService(IEmployeeRepository employeeInterfaces) {
            _employeeInterfaces = employeeInterfaces;
        }

        public async Task<EmployeeDto> AddEmployeeAsync(AddEmployeeDto addEmployeeDto)
        {
            var employee = new Employee()
            {
                Name = addEmployeeDto.Name,
                Mail = addEmployeeDto.Mail,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary,
            };
            var newProduct = await _employeeInterfaces.AddEmployeeAsync(employee);

            return new EmployeeDto()
            {
                Id = newProduct.Id,
                Name = newProduct.Name,
                Mail = newProduct.Mail,
                Phone = newProduct.Phone,
                Salary = newProduct.Salary,
            };

        }

        public async Task DeleteEmployeeAsync(Guid id)
        {
         

            var employee = await _employeeInterfaces.GetEmployeeByIdAsync(id);
            if (employee is null)
            {
                throw new NotImplementedException($"Not Found {id}");
            }
            await _employeeInterfaces.DeleteEmployeeAsync(id);
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            var employee = await _employeeInterfaces.GetAllEmployeesAsync();
            var employeeDtd = employee.Select(e => new EmployeeDto 
            { 
                Id = e.Id,
                Name = e.Name,
                Mail = e.Mail,
                Phone = e.Phone,
                Salary= e.Salary,
            }).ToList();

            return employeeDtd;
        }

        public async Task<EmployeeDto?> GetEmployeeByIdAsync(Guid id)
        {
            var employee = await _employeeInterfaces.GetEmployeeByIdAsync(id);
            if (employee is null)
            {
                throw new NotImplementedException($"Not Found {id}");
            }
            var employeeDto = new EmployeeDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                Mail = employee.Mail,
                Phone = employee.Phone,
                Salary = employee.Salary,
            };
            return employeeDto;
        }

        public async Task UpdateAsync(EditEmployeeDtocs editEmployeeDtocs, Guid id)
        {
            var  employee = await _employeeInterfaces.GetEmployeeByIdAsync(id);
            if (employee is null) 
            {
                throw new NotImplementedException($"Not Found {id}");
            }
            employee.Name = editEmployeeDtocs.Name;
            employee.Mail = editEmployeeDtocs.Mail;
            employee.Phone = editEmployeeDtocs.Phone;
            employee.Salary = editEmployeeDtocs.Salary;
            await _employeeInterfaces.UpdateAsync(employee);
        }
    }
}
