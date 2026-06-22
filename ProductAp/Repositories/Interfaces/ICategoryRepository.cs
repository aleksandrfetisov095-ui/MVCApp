using ProductAp.Models;

namespace ProductAp.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<ProductCategory>> GetAllAsync();
    Task<ProductCategory?> GetByIdAsync(int id);
    Task<ProductCategory> AddAsync(ProductCategory category);
    Task<ProductCategory?> UpdateAsync(ProductCategory category);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}