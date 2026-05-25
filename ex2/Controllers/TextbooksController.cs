using Microsoft.AspNetCore.Mvc;
using ex2.Repositories.Interfaces;

namespace ex2.Controllers;

public class TextbooksController : Controller
{
    private readonly ITextbookRepository _repository;

    public TextbooksController(ITextbookRepository repository)
    {
        _repository = repository;
    }

    public IActionResult Index()
    {
        var textbooks = _repository.Get();
        return View(textbooks);
    }

    public IActionResult Details(int id)
    {
        var textbook = _repository.GetById(id);
        return View(textbook);
    }
}