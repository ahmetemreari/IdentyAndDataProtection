using Microsoft.AspNetCore.DataProtection;

namespace IdentityDataProtectionApp.Services
{
    public class EncryptionService
    {
        //Enctyption servisi
        private readonly IDataProtector _dataProtector;

        public EncryptionService(IDataProtectionProvider dataProtectionProvider)
        //DataProtectionProvider sınıfından bir nesne oluşturulması
        {
            _dataProtector = dataProtectionProvider.CreateProtector("PasswordProtector");
        }

        public string Protect(string plainText)
        {
            //Şifreleme işlemi
            return _dataProtector.Protect(plainText);
        }

        public string Unprotect(string encryptedText)
        //Şifre çözme işlemi
        {
            return _dataProtector.Unprotect(encryptedText);
        }
    }
}
