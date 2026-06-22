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

    public async Task<IEnumerable<ProductCategory>> GetAllAsync()
    {
        return await _context.ProductCategories.ToListAsync();
    }

    public async Task<ProductCategory?> GetByIdAsync(int id)
    {
        return await _context.ProductCategories.FindAsync(id);
    }

    public async Task<ProductCategory> AddAsync(ProductCategory category)
    {
        await _context.ProductCategories.AddAsync(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<ProductCategory?> UpdateAsync(ProductCategory category)
    {
        _context.Entry(category).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await ExistsAsync(category.Id)) return null;
            throw;
        }
        return category;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var category = await _context.ProductCategories.FindAsync(id);
        if (category == null) return false;

        _context.ProductCategories.Remove(category);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.ProductCategories.AnyAsync(e => e.Id == id);
    }
}