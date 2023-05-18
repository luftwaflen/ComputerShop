using ComputerShop.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShop.WebApp.Controllers
{
    public class FindController : Controller
    {
        public FindController()
        {
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
