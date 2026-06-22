using Microsoft.EntityFrameworkCore;
using ex3.Data;
using ex3.Models;
using ex3.Repositories.Interfaces;

namespace ex3.Repositories;

public class CatRepository : ICatRepository
{
    private readonly ApplicationDbContext _context;

    public CatRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Cat>> GetFilteredAsync(string? searchName)
    {
        var query = _context.Cats.Include(c => c.Breed).AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchName))
        {
            query = query.Where(c => c.Name.Contains(searchName));
        }

        return await query.ToListAsync();
    }

    public async Task<List<Cat>> GetAllAsync() =>
        await _context.Cats.Include(c => c.Breed).ToListAsync();

    public async Task<Cat?> GetByIdAsync(int id) =>
        await _context.Cats.Include(c => c.Breed).FirstOrDefaultAsync(c => c.Id == id);

    public async Task<List<Breed>> GetAllBreedsAsync() =>
        await _context.Breeds.ToListAsync();

    public async Task AddCatAsync(Cat cat)
    {
        await _context.Cats.AddAsync(cat);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCatAsync(Cat cat)
    {
        _context.Cats.Update(cat);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCatAsync(int id)
    {
        var cat = await _context.Cats.FindAsync(id);
        if (cat != null)
        {
            _context.Cats.Remove(cat);
            await _context.SaveChangesAsync();
        }
    }
}