using System.ComponentModel.DataAnnotations;

namespace IdentityDataProtectionApp.Models
{
    public class RegisterUserDto
    {
        // Kullanıcı kaydı için gerekli olan bilgiler
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
