using System.ComponentModel.DataAnnotations;

namespace IdentityAndDataProtection.Models
{
    public class LoginRequest
    {

        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Length(6, 20)]
        public string Password { get; set; }
    }
}
