using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Starter.Data;
using Starter.Models;
using System.Diagnostics;

namespace Starter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _context;

        public HomeController(ILogger<HomeController> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Products.Include(p => p.Category);
            return View(await databaseContext.ToListAsync());
        }

        public IActionResult About()
        {
            return View();
        }

        [Route("/category/{slug}")]
        public async Task<IActionResult> Categories(string slug)
        {
            if(slug == null) { return NotFound(); }

            Category category = await _context.Categories.Include(p => p.Products).FirstOrDefaultAsync(c => c.Slug == slug);
            if (category == null) { return NotFound(); }
            return View(category.Products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}