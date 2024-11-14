using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityDataProtectionJWT.Jwt
{
    public static class JwtHelper
    {
        public static string GenerateJwtToken(JwtDto jwtInfo)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                (jwtInfo.SecretKey));

            var credentials = new SigningCredentials(secretKey,SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("Id",jwtInfo.Id.ToString()),
                new Claim("Email",jwtInfo.Email),
                new Claim("UserType",jwtInfo.UserType.ToString()),
                
                // Authorization için (kullanıcı rolleri)
                new Claim(ClaimTypes.Role,jwtInfo.UserType.ToString())

            };

            var expireTime = DateTime.Now.AddMinutes(jwtInfo.ExpireMinutes);

            var tokenDescriptor = new JwtSecurityToken(jwtInfo.Issuer, jwtInfo.Audience,claims,null,expireTime); // token tanımlıyoruz içinde neler olacağını belirtiyoruz
            
            var token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor); 
            
            return token;
        }

        


    }
}
