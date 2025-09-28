using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductMana.Domain.Entities;

namespace ProductMana.Domain.Interfaces
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
