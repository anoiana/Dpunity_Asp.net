using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Infrastructure.Datas;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Repositoties
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) => _context = context;

        public async Task<User> AddAsync(User user)
        {
            await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<bool> UserExistsAsync(string username)
        {
            return await _context.users.AnyAsync(u => u.Username == username);
        }
    }
}
