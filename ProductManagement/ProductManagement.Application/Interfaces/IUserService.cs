using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Application.Dtos.Request;
using ProductManagement.Application.Dtos.Response;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Interfaces
{
    public interface IUserService
    {
        Task<User?> AuthenticateAsync(String email, string password);
        Task<UserDto> RegisterAsync(RegisterRequestDto registerRequestDto);
    }
}
