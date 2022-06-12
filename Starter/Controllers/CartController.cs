using Microsoft.AspNetCore.Mvc;

namespace Starter.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
