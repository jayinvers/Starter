using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Starter.Data;

namespace Starter.Controllers
{
    public class ProductController : Controller
    {
        private DatabaseContext _context;
        public ProductController(DatabaseContext context)
        {
            _context = context;
        }
        [Route("/product/{id:int}")]
        public async Task<IActionResult> Index(int? id)
        {
            if(id == null) { return NotFound(); }

            return View(await _context.Products.FirstOrDefaultAsync(p=>p.ProductId == id));
        }
    }
}
