using ex3.Models;

namespace ex3.Repositories.Interfaces;

public interface ICatRepository
{
    Task<List<Cat>> GetAllAsync();
    Task<Cat?> GetByIdAsync(int id);
    Task<List<Breed>> GetAllBreedsAsync();

    Task AddCatAsync(Cat cat);
    Task UpdateCatAsync(Cat cat);
    Task DeleteCatAsync(int id);
}