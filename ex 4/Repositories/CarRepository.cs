using ex_4.Models;
using ex4.Data;
using ex4.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ex4.Repositories;

public class CarRepository : ICarRepository
{
    private readonly ApplicationDbContext _context;

    public CarRepository(ApplicationDbContext context) => _context = context;

    public async Task<List<Car>> GetAllAsync() =>
        await _context.Cars.Include(c => c.Brand).ToListAsync();

    public async Task<Car?> GetByIdAsync(int id) =>
        await _context.Cars.Include(c => c.Brand).FirstOrDefaultAsync(c => c.Id == id);

    public async Task<List<Brand>> GetAllBrandsAsync() =>
        await _context.Brands.ToListAsync();

    public async Task AddBrandAsync(Brand brand)
    {
        await _context.Brands.AddAsync(brand);
        await _context.SaveChangesAsync();
    }
}