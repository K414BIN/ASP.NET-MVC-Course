using FakeOffice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FakeOffice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Главная страница";
            return View();
        }
      
    }
}