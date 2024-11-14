using IdentityAndDataProtection.Entities;

namespace IdentityDataProtectionJWT.Jwt
{
    public class JwtDto
    {
        public int Id { get; set; } // 3 property kullanıcı ile ilgili almak istediğimiz veriler
        public string Email { get; set; }
        public UserType UserType { get; set; }
        public string SecretKey { get; set; } // 4 property appsettings değerler
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpireMinutes { get; set; }
    }

}
