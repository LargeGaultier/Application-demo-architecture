using Archi.AppUserManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace Archi.AppUserManagement.Persistence
{
    public class UserManagementDbContext : DbContext
    {
        public UserManagementDbContext(DbContextOptions<UserManagementDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>().HasData(new Profile { Id = 1, Code = "adm", Name = "Administrator" });
            modelBuilder.Entity<Profile>().HasData(new Profile { Id = 2, Code = "usr", Name = "User" });
        }

       public DbSet<Profile> Profiles { get; set; }
       public DbSet<User> Users { get; set; }
    }
}
