using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Dtos.Request
{
    public class RegisterRequestDto
    {

        [Required]
        public string Username { get; set; }
        
        [Required] 
        [MinLength(6, ErrorMessage ="Password must be at least 6 characters long.")]
        public string Password { get; set; }
        
        [Required]
        public string Role { get; set; }
    }
}
