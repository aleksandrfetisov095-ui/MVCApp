using ex3.Models;
using ex3.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ex3.Controllers;

public class CatsController : Controller
{
    private readonly ICatRepository _repository;

    public CatsController(ICatRepository repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var cats = await _repository.GetAllAsync();
        return View(cats);
    }

    public async Task<IActionResult> Details(int id)
    {
        var cat = await _repository.GetByIdAsync(id);
        if (cat == null) return NotFound();
        return View(cat);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Brands = await GetBrandsSelectList();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Cat cat)
    {
        if (ModelState.IsValid)
        {
            await _repository.AddCatAsync(cat);
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Brands = await GetBrandsSelectList();
        return View(cat);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var cat = await _repository.GetByIdAsync(id);
        if (cat == null) return NotFound();

        ViewBag.Brands = await GetBrandsSelectList();
        return View(cat);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Cat cat)
    {
        if (id != cat.Id) return NotFound();

        if (ModelState.IsValid)
        {
            await _repository.UpdateCatAsync(cat);
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Brands = await GetBrandsSelectList();
        return View(cat);
    }

    private async Task<List<SelectListItem>> GetBrandsSelectList()
    {
        var breeds = await _repository.GetAllBreedsAsync();
        return breeds.Select(b => new SelectListItem
        {
            Value = b.Id.ToString(),
            Text = b.Name
        }).ToList();
    }
}