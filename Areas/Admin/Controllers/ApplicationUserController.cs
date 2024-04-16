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
using Microsoft.AspNetCore.Identity;
using System.Runtime.InteropServices;

namespace Ciel.Areas.Admin.Controllers
{
    [Area("Admin")]

    [Authorize(Roles = "Admin")]
    public class ApplicationUserController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ApplicationUserController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;

            _userManager = userManager;
            _roleManager = roleManager;
        }
        // GET: Users
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var users = await _context.ApplicationUsers

                .Where(u => u.Id != currentUser.Id)
                .ToListAsync();

            return View(users);
        }
        // GET: Users/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _context.ApplicationUsers

                .FirstOrDefaultAsync(m => m.Id == id);

            ViewData["userId"] = id;

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApplicationUser applicationUser, string password)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(password))
                {
                    ModelState.AddModelError("Password", "Паролата е задължителна.");
                    return View(applicationUser);
                }

                var user = new ApplicationUser
                {
                    Name = applicationUser.Name,
                    LastName = applicationUser.LastName,
                    Email = applicationUser.Email,
                    NormalizedEmail = applicationUser.NormalizedEmail?.ToUpper(),
                    UserName = applicationUser.UserName,
                    NormalizedUserName = applicationUser.UserName?.ToUpper(),
                    PhoneNumber = applicationUser.PhoneNumber,
                    EGN = applicationUser.EGN
                };

                var result = await _userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    // Проверка и добавяне на ролята "ApplicationUser" на потребителя
                    if (!await _roleManager.RoleExistsAsync("Customer"))
                    {
                        await _roleManager.CreateAsync(new IdentityRole("Customer"));
                    }

                    await _userManager.AddToRoleAsync(user, "Customer");

                    // Създаване на карта за потребителя
                    var cart = new Cart { UserId = user.Id };
                    _context.Carts.Add(cart);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(applicationUser);
        }
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Редактиране/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, ApplicationUser model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByIdAsync(id);
                    if (user == null)
                    {
                        return NotFound();
                    }

                    //Актуализиране на потребителските свойства
                    user.Name = model.Name;
                    user.LastName = model.LastName;
                    user.Email = model.Email;
                    user.UserName = model.UserName;
                    user.PhoneNumber = model.PhoneNumber;
                    user.EGN = model.EGN;

                    //Актуализиране на потребителя в базата данни
                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        return View(model);
                    }
                }
                catch (Exception)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }
        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _context.ApplicationUsers.FindAsync(id);

            _context.ApplicationUsers.Remove(user);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
