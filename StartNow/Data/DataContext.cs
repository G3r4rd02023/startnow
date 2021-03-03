using Microsoft.EntityFrameworkCore;
using StartNow.Data.Entities;

namespace StartNow.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>()
                .HasIndex(t => t.Name)
                .IsUnique();

            modelBuilder.Entity<City>()
                .HasIndex(t => t.Name)
                .IsUnique();

        }
    }

}
