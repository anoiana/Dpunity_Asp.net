using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Application.Dtos.Request;
using EmployeeManagement.Application.Dtos.Response;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Interfacaes
{
    public interface IEmployeeService
    {
        Task<EmployeeDto?> GetEmployeeByIdAsync(Guid id);
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
        Task<EmployeeDto> AddEmployeeAsync(AddEmployeeDto addEmployeeDto);
        Task UpdateAsync(EditEmployeeDtocs editEmployeeDtocs, Guid id);
        Task DeleteEmployeeAsync(Guid id);
    }
}
