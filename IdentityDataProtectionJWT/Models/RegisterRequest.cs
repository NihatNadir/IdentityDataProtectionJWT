using System.ComponentModel.DataAnnotations;

namespace IdentityAndDataProtection.Models
{
    public class RegisterRequest
    {
        [EmailAddress]
        public string Email { get; set; }
        [Required]        
        public string Password { get; set; }
    }
}
