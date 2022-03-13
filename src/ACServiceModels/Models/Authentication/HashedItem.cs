using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace ACServiceModels.Models.Authentication
{
    public class HashedItem
    {
        public string Salt { get; }
        public string HashedString { get; }

        public HashedItem(string item)
        {
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: item,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8)
            );

            Salt = Convert.ToBase64String(salt);
            HashedString = hashed;
        }
    }
}
