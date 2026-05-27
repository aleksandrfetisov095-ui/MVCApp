using ex3.Models;
using Microsoft.AspNetCore.SignalR;
namespace ex3.Repositories.Interfaces
{
    public interface ICatRepository
    {
        List<Cat> Get();
        Cat GetById(int id);
    }
}
