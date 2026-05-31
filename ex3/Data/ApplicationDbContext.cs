using Microsoft.EntityFrameworkCore;
using ex3.Models;

namespace ex3.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Cat> Cats { get; set; }
    public DbSet<Breed> Breeds { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cat>()
            .HasOne(c => c.Breed)
            .WithMany(b => b.Cats)
            .HasForeignKey(c => c.BreedId);
    }
}