using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PingYourPackage.Domain.Services
{
    public class CryptService : ICryptoService
    {
        public string EncryptPassword(string password, string salt)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("Password");
            }
            if (string.IsNullOrEmpty(salt))
            {
                throw new ArgumentNullException(nameof(salt));

            }
            using (var sha256 = SHA256.Create())
            {
                var saltedPassord = string.Format("{0}{1}", salt, password);
                byte[] saltedPasswordAsBytes = Encoding.UTF8.GetBytes(saltedPassord);
                return Convert.ToBase64String(sha256.ComputeHash(saltedPasswordAsBytes));


            }

        }

        public string GenerateSalt()
        {
            var data = new byte[0x10];
            using (var cryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                cryptoServiceProvider.GetBytes(data);
                return Convert.ToBase64String(data);
            }
        }
    }
}
