using Microsoft.AspNetCore.Mvc;
using ex3.Models;

namespace ex3.ViewComponents;

public class PaginationViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(int currentPage, int totalPages)
    {
        return View(new PaginationViewModel
        {
            CurrentPage = currentPage,
            TotalPages = totalPages
        });
    }
}

public class PaginationViewModel
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
}