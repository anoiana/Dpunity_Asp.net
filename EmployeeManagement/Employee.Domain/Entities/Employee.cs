using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Mail { get; set; }
        public string? Phone { get; set; }
        public decimal Salary { get; set; }
    }
}
