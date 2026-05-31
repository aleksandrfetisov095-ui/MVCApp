using ex_4.Models;
using Microsoft.EntityFrameworkCore;

namespace ex4.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Brand> Brands { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>()
            .HasOne(c => c.Brand)
            .WithMany(b => b.Cars)
            .HasForeignKey(c => c.BrandId);
    }
}