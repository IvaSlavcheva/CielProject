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
            _context = context;
        }

        public IActionResult Index()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return NotFound();
            }

            Cart? cart = _context
                .Carts
                .Include(c => c.Products)
                .FirstOrDefault(c => c.UserId == userId);

            if (cart == null)
            {
                return NotFound();
            }

            int[] ids = cart.Products.Select(c => c.ProductId).ToArray();
            List<Product> products = new List<Product>();
            var test = new Dictionary<Product, int>();
           
            foreach (var id in ids)
            {
                var current = _context.Products.FirstOrDefault(i => i.Id == id);

                if (test.ContainsKey(current))
                {
                    test[current]++;
                }
                else
                {
                    test.Add(current, 1);
                }
            }
            ViewData["Products"] = test;
            return View(test);
        }

        public IActionResult Create(int? productId)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return NotFound();
            }

            if (productId == null)
            {
                return NotFound();
            }

            var product = _context.Products.Find(productId);

            if (product == null)
            {
                return NotFound();
            }

            Cart? cart = _context.Carts.Include(c => c.Products).FirstOrDefault(c => c.UserId == userId);

            if (cart == null)
            {
                return NotFound();
            }

            Cart_Product Carts_Products = new Cart_Product(cart.Id, product.Id);

            _context.Cart_Products.Add(Carts_Products);
            _context.SaveChanges();

            return RedirectToAction("Index", "Carts", new { area = "Customer" });
        }
        public IActionResult Delete(int? productId)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return NotFound();
            }

            if (productId == null)
            {
                return NotFound();
            }

            Cart? cart = _context.Carts.Include(c => c.Products).FirstOrDefault(c => c.UserId == userId);

            if (cart == null)
            {
                return RedirectToAction("Index", "Carts", new { area = "Customer" });
            }

            var cartProduct = cart.Products.FirstOrDefault(c => c.ProductId == productId);
            if (cartProduct == null)
            {
                return RedirectToAction("Index", "Carts", new { area = "Customer" });
            }

            cart.Products.Remove(cartProduct);
            _context.Carts.Update(cart);
            _context.SaveChanges();

            return RedirectToAction("Index", "Carts", new { area = "Customer" });
        }

    }

}
