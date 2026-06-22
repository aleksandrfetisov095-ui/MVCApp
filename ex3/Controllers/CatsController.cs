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

    public async Task<IActionResult> Index(string? searchName, int page = 1)
    {
        var cats = await _repository.GetFilteredAsync(searchName);

        int pageSize = 10;
        var pagedCats = cats.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        ViewBag.SearchName = searchName;
        ViewBag.TotalPages = (int)Math.Ceiling(cats.Count / (double)pageSize);
        ViewBag.CurrentPage = page;

        return View(pagedCats);
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
        return View(new CatCreateViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CatCreateViewModel model)
    {
        if (ModelState.IsValid)
        {
            string? photoUrl = null;
            if (model.PhotoFile != null && model.PhotoFile.Length > 0)
            {
                photoUrl = await SavePhotoAsync(model.PhotoFile);
            }

            var cat = new Cat
            {
                Name = model.Name,
                Description = model.Description,
                Age = model.Age,
                PhotoSrc = photoUrl ?? "https://via.placeholder.com/300x200?text=No+Photo",
                BreedId = model.BreedId
            };

            await _repository.AddCatAsync(cat);
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Brands = await GetBrandsSelectList();
        return View(model);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var cat = await _repository.GetByIdAsync(id);
        if (cat == null) return NotFound();

        var model = new CatCreateViewModel
        {
            Id = cat.Id,
            Name = cat.Name,
            Description = cat.Description,
            Age = cat.Age,
            CurrentPhotoUrl = cat.PhotoSrc,
            BreedId = cat.BreedId
        };

        ViewBag.Brands = await GetBrandsSelectList();

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, CatCreateViewModel model)
    {
        if (id != model.Id) return NotFound();

        if (ModelState.IsValid)
        {
            var cat = await _repository.GetByIdAsync(id);
            if (cat == null) return NotFound();

            cat.Name = model.Name;
            cat.Description = model.Description;
            cat.Age = model.Age;
            cat.BreedId = model.BreedId;

            if (model.PhotoFile != null && model.PhotoFile.Length > 0)
            {
                if (!string.IsNullOrEmpty(cat.PhotoSrc) && cat.PhotoSrc.StartsWith("/images/"))
                {
                    var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", cat.PhotoSrc.TrimStart('/'));
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                }

                cat.PhotoSrc = await SavePhotoAsync(model.PhotoFile);
            }

            await _repository.UpdateCatAsync(cat);
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Brands = await GetBrandsSelectList();
        return View(model);
    }

    private async Task<string> SavePhotoAsync(IFormFile file)
    {
        if (file == null || file.Length == 0) return null;

        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "cats");
        Directory.CreateDirectory(uploadsFolder);

        var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return $"/images/cats/{uniqueFileName}";
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