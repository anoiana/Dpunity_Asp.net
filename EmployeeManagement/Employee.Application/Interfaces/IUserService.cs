using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Application.Dtos.Request;
using EmployeeManagement.Application.Dtos.Response;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> AuthenticateAsync(string username, string password);
        Task<UserDto> RegisterAsync(RegisterRequestDto registerRequest);
    }
}
