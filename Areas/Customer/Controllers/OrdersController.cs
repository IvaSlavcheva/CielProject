using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ciel.Data;
using Ciel.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Ciel.Areas.Customer.Controllers
{
    [Authorize]
    [Area("Customer")]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var list = _context.Order.Include(o => o.Address).Include(o => o.Products).Where(o => o.UserId == userId).ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Address address)
        {
            if (ModelState.IsValid)
            {
                _context.Addresses.Add(address);
                _context.SaveChanges();

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
                double totalPrice = test.Select(p => p.Key.Price * p.Value).Sum();
                List<Product> productsList = new List<Product>();

                foreach (var item in test)
                {
                    for (int i = 0; i < item.Value; i++)
                    {
                        productsList.Add(_context.Products.FirstOrDefault(n => n.Id == item.Key.Id)!);
                    }
                }

                Order order = new Order
                {
                    AddressId = address.Id,
                    TotalPrice = totalPrice,
                    UserId = userId,
                };

                _context.Orders.Add(order);
                _context.SaveChanges();

                List<OrderProduct> orderProducts = productsList.Select(p => new OrderProduct()
                {
                    OrderId = order.Id,
                    ProductId = p.Id
                }).ToList();

                foreach (var item in orderProducts)
                {
                    _context.OrderProducts.Add(item);
                    _context.SaveChanges();
                }

                _context.SaveChanges();

                cart.Products.Clear();
                _context.Carts.Update(cart);
                _context.SaveChanges();

                return RedirectToAction("Details", new { orderId = order.Id });
            }

            return RedirectToAction("Index", "Carts");
        }
        public IActionResult Details(int orderId)
        {
            Order? order = _context.Orders.Include(o => o.Address).Include(o => o.Products).FirstOrDefault(o => o.Id == orderId);
            if (order == null)
            {
                return RedirectToAction("Index", "Carts");
            }

            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId != order.UserId)
            {
                return RedirectToAction("Index", "Carts");
            }

            int[] ids = order.Products.Select(c => c.ProductId).ToArray();
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

            return View(order);
        }
    }
}