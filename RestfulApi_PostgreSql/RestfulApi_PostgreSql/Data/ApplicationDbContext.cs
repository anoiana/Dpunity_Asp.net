using Microsoft.EntityFrameworkCore;
using RestfulApi_PostgreSql.Models;

namespace RestfulApi_PostgreSql.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
    }
}
