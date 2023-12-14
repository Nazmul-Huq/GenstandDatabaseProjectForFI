using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;

namespace GenstandDatabaseProjectForFI.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Genstand> Genstands { get; set; }

        public DbSet<Film> Film { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>().HasMany<Genstand>(G => G.Genstands).WithOne(G => G.Film).HasForeignKey(G => G.Id).IsRequired(false);
        }
    }
}
