using ex2.Models;

namespace ex2.Repositories.Interfaces;

public interface ITextbookRepository
{
    List<Textbook> Get();
    Textbook GetById(int id);
}