using System.ComponentModel.DataAnnotations;

namespace PostgresJwtApi.Dtos.Resquest
{
    public class LoginResquest
    {
        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }
    }
}
