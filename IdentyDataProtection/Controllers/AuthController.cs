using IdentityDataProtectionApp.Data;
using IdentityDataProtectionApp.Models;
using IdentityDataProtectionApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace IdentityDataProtectionApp.Controllers
// Bu controller sınıfı, kullanıcı kaydı işlemlerini gerçekleştirir.
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase

    {
        // Veritabanı bağlantısı ve şifreleme servisi
        private readonly ApplicationDbContext _context;
        private readonly EncryptionService _encryptionService;

        public AuthController(ApplicationDbContext context, EncryptionService encryptionService)
        {
            _context = context;
            _encryptionService = encryptionService;
        }
        //Kullanıcı kaydı işlemi

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
                // Email adresinin dogrulugu

            // Şifreleme
            var encryptedPassword = _encryptionService.Protect(dto.Password);
            

            var user = new User
            {
                // Kullanıcı nesnesi oluşturulması ve veritabanına kaydedilmesi
                Email = dto.Email,
                Password = encryptedPassword
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("Kayıt islemi basariyla tamamlandi!");
        }
    }
}
