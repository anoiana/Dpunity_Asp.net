using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetEmployeeByIdAsync(Guid id);
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteEmployeeAsync(Guid id);
    }
}
