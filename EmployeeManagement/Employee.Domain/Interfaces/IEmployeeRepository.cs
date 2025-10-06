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
        Task<Employees?> GetEmployeeByIdAsync(Guid id);
        Task<IEnumerable<Employees>> GetAllEmployeesAsync();
        Task<Employees> AddEmployeeAsync(Employees employee);
        Task UpdateAsync(Employees employee);
        Task DeleteEmployeeAsync(Guid id);
    }
}
