using System.ComponentModel.DataAnnotations;

namespace PostgresJwtApi.Dtos.Resquest
{
    public class RegisterRequest
    {
        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }
        [Required] public string Role { get; set; }
    }
}
