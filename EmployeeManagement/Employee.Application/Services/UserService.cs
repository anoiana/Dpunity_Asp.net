using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Application.Dtos.Request;
using EmployeeManagement.Application.Dtos.Response;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;

namespace Employee.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = await _userRepository.GetByUsernameAsync(username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Passwordhash))
            {
                return null;
            }

            return user;
        }

        public async Task<UserDto> RegisterAsync(RegisterRequestDto registerRequest)
        {
            if (await _userRepository.UserExistsAsync(registerRequest.Username))
            {
                throw new System.ArgumentException("Username already exists.");
            }

            var user = new User
            {
                Id = System.Guid.NewGuid(),
                Username = registerRequest.Username,
                Passwordhash = BCrypt.Net.BCrypt.HashPassword(registerRequest.Password),
                Role = registerRequest.Role
            };

            var addedUser = await _userRepository.AddAsync(user);

            return new UserDto { Id = addedUser.Id, Username = addedUser.Username, Role = addedUser.Role };
        }
    }
}
