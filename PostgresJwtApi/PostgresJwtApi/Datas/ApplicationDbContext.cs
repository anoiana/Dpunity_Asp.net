using Microsoft.EntityFrameworkCore;
using PostgresJwtApi.Models;

namespace PostgresJwtApi.Datas
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } 
    }
}
