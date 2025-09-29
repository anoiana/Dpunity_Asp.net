using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Infrastructure.Datas;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            await _context.employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }


        public async Task DeleteEmployeeAsync(Guid id)
        {
           var employee = await _context.employees.FindAsync(id);
            if (employee is null)
            {
                throw new NotImplementedException($"Not found {id}");
            }
            _context.employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            var employee = await _context.employees.ToListAsync();
            return employee;
        }

        public async Task<Employee?> GetEmployeeByIdAsync(Guid id)
        {
            var employee = await _context.employees.FindAsync(id);
            if (employee is null)
            {
                throw new NotImplementedException($"Not found {id}");
            }
            return employee;
        }

        public async Task UpdateAsync(Employee employee)
        {
            var e = new Employee()
            {
                Name = employee.Name,
                Mail = employee.Mail,
                Phone = employee.Phone,
                Salary = employee.Salary,
            };
            await _context.SaveChangesAsync();
        }
    }
}
