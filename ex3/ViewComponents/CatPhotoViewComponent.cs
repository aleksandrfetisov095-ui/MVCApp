using ex3.Models;
using Microsoft.AspNetCore.Mvc;

namespace ex3.ViewComponents;

public class CatPhotoViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(Cat cat)
    {
        return View(cat);
    }
}