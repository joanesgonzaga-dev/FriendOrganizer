using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FriendOrganizer.DataAcess.Data
{
    public class ApplicationMainDbContext : DbContext
    {
        public ApplicationMainDbContext(DbContextOptions<ApplicationMainDbContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Friend>().HasData(
                new Friend { Id = 1, FirstName = "Thomas", LastName = "Hubert", Email = "thomas.hubert@example.com" },
                new Friend { Id = 2, FirstName = "Andreas", LastName = "Boehler", Email = "boehler@example.com" },
                new Friend { Id = 3, FirstName = "Julia", LastName = "Huber", Email = "hubertjulia@example.com" },
                new Friend { Id = 4, FirstName = "Chrissi", LastName = "Egin", Email = "egin38@example.com" }
            );

            
            modelBuilder.Entity<Friend>().Property(f => f.FirstName).IsRequired().HasMaxLength(60);
        }
        public DbSet<Friend>? Friends { get; set; }
    }
}