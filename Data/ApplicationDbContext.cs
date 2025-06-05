using cantine_univ.Models;
using Microsoft.EntityFrameworkCore;

namespace cantine_univ.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Contraintes d’unicité
            modelBuilder.Entity<Student>()
                .HasIndex(e => e.Email)
                .IsUnique();

            modelBuilder.Entity<Student>()
                .HasIndex(e => e.Numero)
                .IsUnique();
        }
    }
}
