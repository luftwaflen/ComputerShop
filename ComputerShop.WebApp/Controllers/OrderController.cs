using Microsoft.AspNetCore.Mvc;

namespace ComputerShop.WebApp.Controllers;

public class OrderController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}