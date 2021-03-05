using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StartNow.Data.Entities;

namespace StartNow.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Company> Companies{ get; set; }

        public DbSet<CompanyCustomer> CompanyCustomers { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>()
                .HasIndex(t => t.Name)
                .IsUnique();

            modelBuilder.Entity<City>()
                .HasIndex(t => t.Name)
                .IsUnique();

            modelBuilder.Entity<Company>()
            .HasIndex(t => t.Name)
            .IsUnique();


        }
    }

}
