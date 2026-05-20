using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Главная страница";
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "О себе";
            ViewBag.FullName = "Фетисов Александр Вячеславович";
            ViewBag.Age = 19;
            ViewBag.Email = "aleksandrFet@gmail.com";
            ViewBag.Phone = "+7 (999) 123-45-67";
            ViewBag.Bio = "Студент, изучающий ASP.NET";

            return View();
        }
    }
}