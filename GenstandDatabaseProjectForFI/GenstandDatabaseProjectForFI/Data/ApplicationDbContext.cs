using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;

namespace GenstandDatabaseProjectForFI.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Genstand> Genstands { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
            modelBuilder.Entity<Film>()
                .HasMany<Genstand>(G => G.Genstands)
                .WithOne(f => f.Film)
                .HasForeignKey("FilmId") // EF core will create a column name "FilmId" automatically in the Genstands table
                .IsRequired(false);


            modelBuilder.Entity<Category>()
                   .HasMany<Genstand>(G => G.Genstands)
                   .WithOne(c => c.Category)
                   .HasForeignKey("CategoryId") // EF core vil automatisk oprette en kolonne "FilmId" i Genstands tabellen
                   .IsRequired(false);

            modelBuilder.Entity<Location>()
                   .HasMany<Genstand>(G => G.Genstands)
                   .WithOne(l => l.Location)
                   .HasForeignKey("LocationId") // EF core vil automatisk oprette en kolonne "LocationId" i Genstands tabellen
                   .IsRequired(false);
        }
    }
}
