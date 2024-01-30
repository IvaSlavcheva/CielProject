using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ciel.Data;
using Ciel.Models;
using Ciel.Models.NewModelView;
using System.Numerics;

namespace Ciel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Products.Include(p => p.Catalog);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Products/Details/5
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

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CatalogId"] = new SelectList(_context.Catalogs, "Id", "CatalogName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductImage product)
        {
            if(product.Picture == null)
            {
                ModelState.AddModelError("Picture", "Трябва да се качи снимка.");
            }

            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadeFile(product);
                Product productI = new Product
                {
                    ProductName = product.ProductName,
                    Description = product.Description,
                    Picture = uniqueFileName,
                    Price = product.Price,
                    CatalogId = product.CatalogId
                };
                _context.Add(productI);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CatalogId"] = new SelectList(_context.Catalogs, "Id", "CatalogName", product.CatalogId);
            return View(product);
        }
        private string UploadeFile(ProductImage actor)
        {
            string uniqueFileName = null;
            if (actor.Picture != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + actor.Picture.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                Console.WriteLine(filePath);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    actor.Picture.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CatalogId"] = new SelectList(_context.Catalogs, "Id", "CatalogName", product.CatalogId);

            ProductImage productImage = new ProductImage
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                CatalogId = product.CatalogId,
                Picture = GetImage($"{webHostEnvironment.WebRootPath}/images/{product.Picture}"),
            };


            return View(productImage);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductImage product)
        {
            if (ModelState.IsValid)
            {
                Product? updateProduct = _context.Products.Find(product.Id);

                if (updateProduct == null)
                {
                    ViewData["CatalogId"] = new SelectList(_context.Catalogs, "Id", "CatalogName", product.CatalogId);
                    return View(product);
                }

                if (product.Picture != null)
                {
                    if (System.IO.File.Exists($"{webHostEnvironment.WebRootPath}/images/{updateProduct.Picture}"))
                    {
                        System.IO.File.Delete($"{webHostEnvironment.WebRootPath}/images/{updateProduct.Picture}");
                    }

                    updateProduct.Picture = UploadeFile(product);
                }

                updateProduct.ProductName = product.ProductName;
                updateProduct.Description = product.Description;
                updateProduct.Price = product.Price;
                updateProduct.CatalogId = product.CatalogId;

                _context.Update(updateProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CatalogId"] = new SelectList(_context.Catalogs, "Id", "CatalogName", product.CatalogId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        public IFormFile GetImage(string path)
        {
            if (!System.IO.File.Exists(path))
            {
                return null;
            }

            using (var stream = new FileStream(path, FileMode.Open))
            {
                var formFile = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                    Headers = new HeaderDictionary(),
                    ContentType = "image/*"
                };

                return formFile;
            }
        }
    }
}
