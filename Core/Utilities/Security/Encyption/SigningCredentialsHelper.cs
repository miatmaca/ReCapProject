using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encyption
{
   public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey security)
        {
            return new SigningCredentials(security, SecurityAlgorithms.HmacSha512Signature);//1.parametreguvenlik anahtarın, 2. parametre şifreleme algoritma
        }
    }
}
