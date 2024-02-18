using Ciel.Data;
using Ciel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ciel.Areas.Customer.Controllers
{
	[Area("Customer")]
	public class ProductsController : Controller
	{
		private readonly ApplicationDbContext _context;

		public ProductsController(ApplicationDbContext context)
		{
			this._context = context;
		}
		public async Task<IActionResult> Index(string nameSearch)
		{
			ViewData["NameSearch"] = nameSearch;

			// Get all products with optional filtering by name
			IQueryable<Product> query = _context.Products
				.Include(p => p.Catalog);

			if (!string.IsNullOrEmpty(nameSearch))
			{
				query = query.Where(p => p.ProductName.Contains(nameSearch));
			}
			List<Product> productList = await query.ToListAsync();
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
				.FirstOrDefaultAsync(m => m.Id == id);
			if (product == null)
			{
				return NotFound();
			}
			return View(product);
		}
	}
}

