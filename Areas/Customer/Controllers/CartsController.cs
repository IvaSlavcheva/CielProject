using Ciel.Data;
using Ciel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Ciel.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartsController(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Cart? cart = _context.Carts.Include(c => c.Products).FirstOrDefault(c => c.UserId == userId);

            if (cart == null)
            {
                return NotFound();
            }

            var ids = cart.Products.Select(p => p.ProductId).ToList();

            List<Product> products = new List<Product>();

            foreach (var id in ids)
            {
                products.Add(_context.Products.Find(id));
            }

            return View(products);
        }

        public IActionResult Create(int productId)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if(userId == null)
            {
                return NotFound();
            }

            if(productId == 0) 
            {
                return NotFound();
            }

            var product = _context.Products.FirstOrDefault(p => p.Id == productId);

            if(product == null)
            {
                return NotFound();
            }

            Cart? cart = _context.Carts.Include(c => c.Products).FirstOrDefault(c => c.UserId == userId);

            if(cart == null)
            {
                return NotFound();
            }

            if(cart.Products.Any(p => p.ProductId == productId))
            {
                return RedirectToAction("Index", "Carts", new { area = "Customer" });
            }

            Cart_Product cart_Product = new Cart_Product(cart.Id, productId);

            _context.Cart_Products.Add(cart_Product);
            _context.SaveChanges();


            return RedirectToAction("Index", "Carts", new {area = "Customer"});
        }
    }
}
