using ex3.Models;
using ex3.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ex3.ViewComponents;

public class CategoryMenuViewComponent : ViewComponent
{
    private readonly ICatRepository _catRepository;

    public CategoryMenuViewComponent(ICatRepository catRepository)
    {
        _catRepository = catRepository;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var breeds = await _catRepository.GetAllBreedsAsync();
        return View(breeds);
    }
}