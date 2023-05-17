using Microsoft.AspNetCore.Mvc;

namespace ComputerShop.WebApp.Controllers
{
    public class FindController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
