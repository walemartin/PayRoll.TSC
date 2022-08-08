using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PayRoll.TSC.Data;
using PayRoll.TSC.Models;

namespace PayRoll.TSC.Controllers
{
    public class NavigationMenuViewModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NavigationMenuViewModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NavigationMenuViewModels
        public async Task<IActionResult> Index()
        {
              return _context.NavigationMenuViewModel != null ? 
                          View(await _context.NavigationMenuViewModel.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.NavigationMenuViewModel'  is null.");
        }

        // GET: NavigationMenuViewModels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.NavigationMenuViewModel == null)
            {
                return NotFound();
            }

            var navigationMenuViewModel = await _context.NavigationMenuViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (navigationMenuViewModel == null)
            {
                return NotFound();
            }

            return View(navigationMenuViewModel);
        }

        // GET: NavigationMenuViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NavigationMenuViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ParentMenuId,Area,ControllerName,ActionName,IsExternal,ExternalUrl,Permitted,DisplayOrder,Visible")] NavigationMenuViewModel navigationMenuViewModel)
        {
            if (ModelState.IsValid)
            {
                navigationMenuViewModel.Id = Guid.NewGuid();
                _context.Add(navigationMenuViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(navigationMenuViewModel);
        }

        // GET: NavigationMenuViewModels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.NavigationMenuViewModel == null)
            {
                return NotFound();
            }

            var navigationMenuViewModel = await _context.NavigationMenuViewModel.FindAsync(id);
            if (navigationMenuViewModel == null)
            {
                return NotFound();
            }
            return View(navigationMenuViewModel);
        }

        // POST: NavigationMenuViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,ParentMenuId,Area,ControllerName,ActionName,IsExternal,ExternalUrl,Permitted,DisplayOrder,Visible")] NavigationMenuViewModel navigationMenuViewModel)
        {
            if (id != navigationMenuViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(navigationMenuViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NavigationMenuViewModelExists(navigationMenuViewModel.Id))
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
            return View(navigationMenuViewModel);
        }

        // GET: NavigationMenuViewModels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.NavigationMenuViewModel == null)
            {
                return NotFound();
            }

            var navigationMenuViewModel = await _context.NavigationMenuViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (navigationMenuViewModel == null)
            {
                return NotFound();
            }

            return View(navigationMenuViewModel);
        }

        // POST: NavigationMenuViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.NavigationMenuViewModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.NavigationMenuViewModel'  is null.");
            }
            var navigationMenuViewModel = await _context.NavigationMenuViewModel.FindAsync(id);
            if (navigationMenuViewModel != null)
            {
                _context.NavigationMenuViewModel.Remove(navigationMenuViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NavigationMenuViewModelExists(Guid id)
        {
          return (_context.NavigationMenuViewModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
