using LocationSearchApplicationAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LocationSearchApiMVCWithUsers.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<LocationImage> LocationImages { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Venue> Venues { get; set; }

    }
}