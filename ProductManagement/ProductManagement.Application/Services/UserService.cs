using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Application.Dtos.Request;
using ProductManagement.Application.Dtos.Response;
using ProductManagement.Application.Interfaces;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interfaces;

namespace ProductManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public async Task<User?> AuthenticateAsync(String email, string password) {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return null;
            }

            return user;
        }

        public async Task<UserDto> RegisterAsync(RegisterRequestDto registerRequestDto) 
        {
            var existingUser = await _userRepository.GetByEmailAsync(registerRequestDto.Email);
            if (existingUser != null) {
                throw new System.ArgumentException("Email is already existed!");
            }
            var user = new User()
            {
                Id = System.Guid.NewGuid(),
                Username = registerRequestDto.Username,
                Email = registerRequestDto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerRequestDto.Password),
                Role = registerRequestDto.Role
            };
            var addedUser = await _userRepository.AddAsync(user);
            return new UserDto
            {
                Id = addedUser.Id,
                Username = addedUser.Username,
                Role = addedUser.Role
            };
        }

    }
}
