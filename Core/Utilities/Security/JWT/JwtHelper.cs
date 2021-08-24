using Core.Entities.Entity;
using Core.Utilities.Security.Encyption;
using Core.Utilities.Security.Extension;
using Entities.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;


namespace Core.Utilities.Security.JWT
{
    public class JwtHelper:ITokenHelper
    {
       
        //private readonly IOptions<TokenConnection> _appSettings;
        //IOptions<TokenConnection> ;

        public IConfiguration Configuration { get; } //Apı deki appsetting i okumaya olanak sağlar.
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;//accestoken ne zaman geçersileşecek
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions=Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            //benım değerlerim confıguratıon(appsetting) daki TokenOptions bölümünü al .TokenOptionsa ekle.
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);//Ne zaman kadar .Şimdiki zamana verilen dakika kadar süüre ekler 
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);//Securityhelperın create.s.key aracılıgıyla elimdeki token optionsdaki secutiryi kullanarak onu oluştur
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);//hangi algoritma signingcredential helperdaki metodda yazıyor.
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

           return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
            
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
           SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }

}

