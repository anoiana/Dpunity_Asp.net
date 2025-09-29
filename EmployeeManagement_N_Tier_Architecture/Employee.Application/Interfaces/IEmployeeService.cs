using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductMana.Application.Dtos;
using ProductMana.Domain.Entities;

namespace ProductMana.Application.Interfaces
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
