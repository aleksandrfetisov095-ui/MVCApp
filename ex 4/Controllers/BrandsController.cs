using Microsoft.AspNetCore.Mvc;
using ex_4.Models;
using ex4.Repositories.Interfaces;

namespace ex4.Controllers;

public class BrandsController : Controller
{
    private readonly ICarRepository _repository;

    public BrandsController(ICarRepository repository)
    {
        _repository = repository;
    }

    public IActionResult Create()
    {
        ViewData["Title"] = "Добавить бренд";
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Brand brand)
    {
        if (string.IsNullOrWhiteSpace(brand.Name))
        {
            ModelState.AddModelError("Name", "Название бренда обязательно");
            return View(brand);
        }

        await _repository.AddBrandAsync(brand);

        return RedirectToAction("Index", "Home");
    }
}