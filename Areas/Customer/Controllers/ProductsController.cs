using Ciel.Data;
using Ciel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciel.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string nameSearch)
        {
            ViewData["NameSearch"] = nameSearch;

            IQueryable<Product> query = _context.Products
                .Include(p => p.Catalog);

            if (!string.IsNullOrEmpty(nameSearch))
            {
                query = query.Where(p => p.ProductName.Contains(nameSearch));
            }

            List<Product> productList = await query.ToListAsync();
            return View(productList);
        }

        [HttpGet]
        public async Task<IActionResult> SearchByCatalog(int? catalogId)
        {
            ViewData["CatalogId"] = catalogId;

            IQueryable<Product> query = _context.Products
                .Include(p => p.Catalog);

            if (catalogId.HasValue)
            {
                query = query.Where(p => p.CatalogId == catalogId.Value);
            }

            List<Product> productList = await query.ToListAsync();
            ViewData["Catalogs"] = await _context.Catalogs.ToListAsync();

            return View(productList);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Catalog)
                .Include(p => p.Reviews) // Include reviews
                .FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(int productId, string description)
        {
            var product = await _context.Products.FindAsync(productId);

            if (product == null)
            {
                return NotFound();
            }

            var review = new Review(productId, description);

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            // Redirect back to the product details page after adding the review
            return RedirectToAction("Details", new { id = productId });
        }
    }
}


