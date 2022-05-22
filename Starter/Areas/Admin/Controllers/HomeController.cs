using Microsoft.AspNetCore.Mvc;

namespace Starter.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
