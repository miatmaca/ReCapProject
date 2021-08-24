using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)//passwordun hashını yaptıgımız bölüm
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())//Hash oluştururken hangi algoritmayı kullanıcagımızı soylüyoruz
            {
                passwordSalt = hmac.Key;//passwordsalt'da anahtarımızı tutuyoruz
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//bytes e çeviriyoruz

            }

        }
        //password kullanıcının girdiği parola
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))//anahtarımızı(tuz) kullanarak doğrulama yapıyoruz
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }

                }
                return true;
            }

        }
    }
}
