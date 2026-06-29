using Microsoft.EntityFrameworkCore;
using ProductAp.Data;
using ProductAp.Models;
using ProductAp.Repositories.Interfaces;

namespace ProductAp.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductCategory>> GetAllAsync() =>
        await _context.ProductCategories.ToListAsync();

    public async Task<ProductCategory?> GetByIdAsync(int id) =>
        await _context.ProductCategories.FindAsync(id);

    public async Task<ProductCategory> AddAsync(ProductCategory category)
    {
        await _context.ProductCategories.AddAsync(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<ProductCategory?> UpdateAsync(int id, ProductCategory category)
    {
        var existing = await _context.ProductCategories.FindAsync(id);
        if (existing == null) return null;

        existing.Name = category.Name;
        existing.Description = category.Description;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var category = await _context.ProductCategories.FindAsync(id);
        if (category == null) return false;

        _context.ProductCategories.Remove(category);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(int id) =>
        await _context.ProductCategories.AnyAsync(c => c.Id == id);
}