using System.ComponentModel.DataAnnotations;

namespace PostgresJwtApi.Models
{
    public class User
    {
        [Key] public Guid Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string PasswordHash { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Role { get; set; }
    }
}
