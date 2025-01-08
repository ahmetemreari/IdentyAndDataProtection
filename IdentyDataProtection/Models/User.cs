using System.ComponentModel.DataAnnotations;

namespace IdentityDataProtectionApp.Models
{
    public class User
    {
        //Kullanıcı modeli
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
