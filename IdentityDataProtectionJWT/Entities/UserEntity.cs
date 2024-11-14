using System.ComponentModel.DataAnnotations;

namespace IdentityAndDataProtection.Entities
{
    public class UserEntity
    {
        public UserEntity()
        {
            CreatedDate = DateTime.Now;
        }
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Length(6, 20)]
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public UserType UserType { get; set; }
    }

    public enum UserType
    {
        User,Admin
    }
}
