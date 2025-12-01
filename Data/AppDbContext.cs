using Microsoft.EntityFrameworkCore;
using ProductsApi.Entities;
using System.Security.Cryptography;
using System.Text;

namespace ProductsApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            CreateAdminUser(modelBuilder);
        }

        private void CreateAdminUser(ModelBuilder modelBuilder)
        {
            var username = "admin";
            var password = "password123";

            using var hmac = new HMACSHA512();

            var passwordSalt = hmac.Key;
            var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = username,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                }
            );
        }
    }
}
