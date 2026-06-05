using Microsoft.AspNetCore.Mvc;
using ex3.Repositories.Interfaces;

namespace ex3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICatRepository _catRepository;

        public HomeController(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public async Task<IActionResult> Index()
        {
            var cats = await _catRepository.GetAllAsync();
            return View(cats);
        }

        public async Task<IActionResult> Details(int id)
        {
            var cat = await _catRepository.GetByIdAsync(id);
            if (cat == null) return NotFound();
            return View(cat);
        }

        public async Task<IActionResult> Contact()
        {
            ViewData["Title"] = "Контакты";
            ViewBag.Cats = await _catRepository.GetAllAsync();
            return View();
        }
    }
}