using ex2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ex2.Controllers;

public class TextbooksController : Controller
{
    private readonly TextbookRepository _repository;

    public TextbooksController()
    {
        _repository = new TextbookRepository();
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