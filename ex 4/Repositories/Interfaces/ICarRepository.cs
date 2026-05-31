using ex_4.Models;

namespace ex4.Repositories.Interfaces;

public interface ICarRepository
{
    Task<List<Car>> GetAllAsync();
    Task<Car?> GetByIdAsync(int id);
}