using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostgresJwtApi.Models;
using System.Security.Claims;

namespace PostgresJwtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] 
    public class DataController : ControllerBase
    {
        [HttpGet("profile")]
        public IActionResult GetProfile()
        {
            var username = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var role = User.FindFirstValue(ClaimTypes.Role);
            var userId = User.FindFirstValue("UserId");

            return Ok(new { UserId = userId, Username = username, Role = role });
        }

        [HttpGet("admin-data")]
        [Authorize(Roles = "Admin")] 
        public IActionResult GetAdminData()
        {
            return Ok("This is sensitive data, accessible only by Admins.");
        }
    }
}
