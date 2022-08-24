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
    public class PensionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PensionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pensions
        public async Task<IActionResult> Index()
        {
              return _context.Pension != null ? 
                          View(await _context.Pension.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Pension'  is null.");
        }

        // GET: Pensions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pension == null)
            {
                return NotFound();
            }

            var pension = await _context.Pension
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pension == null)
            {
                return NotFound();
            }

            return View(pension);
        }

        // GET: Pensions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pensions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Category,Question,PensionPercentage")] Pension pension)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pension);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pension);
        }

        // GET: Pensions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pension == null)
            {
                return NotFound();
            }

            var pension = await _context.Pension.FindAsync(id);
            if (pension == null)
            {
                return NotFound();
            }
            return View(pension);
        }

        // POST: Pensions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Category,Question,PensionPercentage")] Pension pension)
        {
            if (id != pension.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pension);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PensionExists(pension.Id))
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
            return View(pension);
        }

        // GET: Pensions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pension == null)
            {
                return NotFound();
            }

            var pension = await _context.Pension
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pension == null)
            {
                return NotFound();
            }

            return View(pension);
        }

        // POST: Pensions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pension == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Pension'  is null.");
            }
            var pension = await _context.Pension.FindAsync(id);
            if (pension != null)
            {
                _context.Pension.Remove(pension);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PensionExists(int id)
        {
          return (_context.Pension?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
