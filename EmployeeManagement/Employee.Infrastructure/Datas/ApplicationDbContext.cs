using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Infrastructure.Datas
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {}
        public DbSet<Employees> employees { get; set; }
        public DbSet<User> users { get; set; }
    }
}
