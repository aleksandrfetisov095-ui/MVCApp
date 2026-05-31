using Microsoft.AspNetCore.Mvc;
using ex4.Repositories.Interfaces;

namespace ex4.Controllers;

public class HomeController : Controller
{
    private readonly ICarRepository _repo;
    public HomeController(ICarRepository repo) => _repo = repo;

    public async Task<IActionResult> Index() => View(await _repo.GetAllAsync());

    public async Task<IActionResult> Details(int id)
    {
        var car = await _repo.GetByIdAsync(id);
        return car == null ? NotFound() : View(car);
    }

    public IActionResult Contact()
    {
        ViewData["Title"] = "Контакты";
        return View();
    }
}