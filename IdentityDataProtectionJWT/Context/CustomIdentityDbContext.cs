using IdentityAndDataProtection.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityAndDataProtection.Context
{
    public class CustomIdentityDbContext : DbContext
    {
        public CustomIdentityDbContext(DbContextOptions<CustomIdentityDbContext> options) : base(options)
        { 

        }
                  
        
        public DbSet<UserEntity> Users  => Set<UserEntity>();


    }
}
