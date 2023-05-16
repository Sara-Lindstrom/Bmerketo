
using Bmerketo.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo.Contexts
{
    public class IdentityContext : IdentityDbContext<IdentityUser>
    {

        public IdentityContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole { Name = "admin", NormalizedName = "ADMIN"},
                    new IdentityRole { Name = "user", NormalizedName = "USER"});

            base.OnModelCreating(builder);
        }

        public DbSet<UserProfileEntity> UserProfiles { get; set; }
        public DbSet<AdressEntity> Adresses { get; set; }
    }
}
