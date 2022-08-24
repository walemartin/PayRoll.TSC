using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PayRoll.TSC.Data;
using PayRoll.TSC.PayRollModel;

namespace PayRoll.TSC.Controllers
{
    public class StateOfOriginsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StateOfOriginsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StateOfOrigins
        public async Task<IActionResult> Index()
        {
              return _context.StateOfOrigin != null ? 
                          View(await _context.StateOfOrigin.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.StateOfOrigin'  is null.");
        }

        // GET: StateOfOrigins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StateOfOrigin == null)
            {
                return NotFound();
            }

            var stateOfOrigin = await _context.StateOfOrigin
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stateOfOrigin == null)
            {
                return NotFound();
            }

            return View(stateOfOrigin);
        }

        // GET: StateOfOrigins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StateOfOrigins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] StateOfOrigin stateOfOrigin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stateOfOrigin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stateOfOrigin);
        }

        // GET: StateOfOrigins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StateOfOrigin == null)
            {
                return NotFound();
            }

            var stateOfOrigin = await _context.StateOfOrigin.FindAsync(id);
            if (stateOfOrigin == null)
            {
                return NotFound();
            }
            return View(stateOfOrigin);
        }

        // POST: StateOfOrigins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] StateOfOrigin stateOfOrigin)
        {
            if (id != stateOfOrigin.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stateOfOrigin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StateOfOriginExists(stateOfOrigin.ID))
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
            return View(stateOfOrigin);
        }

        // GET: StateOfOrigins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StateOfOrigin == null)
            {
                return NotFound();
            }

            var stateOfOrigin = await _context.StateOfOrigin
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stateOfOrigin == null)
            {
                return NotFound();
            }

            return View(stateOfOrigin);
        }

        // POST: StateOfOrigins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StateOfOrigin == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StateOfOrigin'  is null.");
            }
            var stateOfOrigin = await _context.StateOfOrigin.FindAsync(id);
            if (stateOfOrigin != null)
            {
                _context.StateOfOrigin.Remove(stateOfOrigin);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StateOfOriginExists(int id)
        {
          return (_context.StateOfOrigin?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
