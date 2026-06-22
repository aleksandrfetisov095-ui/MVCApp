using Microsoft.EntityFrameworkCore;
using ProductAp.Models;
using System.Collections.Generic;

namespace ProductAp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ProductCategory> ProductCategories { get; set; }
}