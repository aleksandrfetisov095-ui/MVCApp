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

        public IActionResult Index()
        {
            var cats = _catRepository.Get();
            return View(cats);
        }

        public IActionResult Details(int id)
        {
            var cat = _catRepository.GetById(id);
            return View(cat);
        }

        public IActionResult Contact()
        {
            ViewData["Title"] = "Контакты";
            ViewBag.Cats = _catRepository.Get();
            return View();
        }
    }
}