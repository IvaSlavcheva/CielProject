﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ciel.Data;
using Ciel.Models;

namespace Ciel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CatalogsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatalogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Catalogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Catalogs.ToListAsync());
        }

        // GET: Catalogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalog = await _context.Catalogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalog == null)
            {
                return NotFound();
            }

            return View(catalog);
        }

        // GET: Catalogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Catalogs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CatalogName")] Catalog catalog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catalog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalog);
        }

        // GET: Catalogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalog = await _context.Catalogs.FindAsync(id);
            if (catalog == null)
            {
                return NotFound();
            }
            return View(catalog);
        }

        // POST: Catalogs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CatalogName")] Catalog catalog)
        {
            if (id != catalog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogExists(catalog.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(catalog);
        }

        // GET: Catalogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalog = await _context.Catalogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalog == null)
            {
                return NotFound();
            }

            return View(catalog);
        }

        // POST: Catalogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catalog = await _context.Catalogs.FindAsync(id);
            if (catalog != null)
            {
                _context.Catalogs.Remove(catalog);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogExists(int id)
        {
            return _context.Catalogs.Any(e => e.Id == id);
        }
    }
}
