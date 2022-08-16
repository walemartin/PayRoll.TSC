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
    public class NextOfKinsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NextOfKinsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NextOfKins
        public async Task<IActionResult> Index()
        {
              return _context.NextOfKin != null ? 
                          View(await _context.NextOfKin.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.NextOfKin'  is null.");
        }

        // GET: NextOfKins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NextOfKin == null)
            {
                return NotFound();
            }

            var nextOfKin = await _context.NextOfKin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nextOfKin == null)
            {
                return NotFound();
            }

            return View(nextOfKin);
        }

        // GET: NextOfKins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NextOfKins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StaffNo,Name,PhoneNumber,Address")] NextOfKin nextOfKin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nextOfKin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nextOfKin);
        }

        // GET: NextOfKins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NextOfKin == null)
            {
                return NotFound();
            }

            var nextOfKin = await _context.NextOfKin.FindAsync(id);
            if (nextOfKin == null)
            {
                return NotFound();
            }
            return View(nextOfKin);
        }

        // POST: NextOfKins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StaffNo,Name,PhoneNumber,Address")] NextOfKin nextOfKin)
        {
            if (id != nextOfKin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nextOfKin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NextOfKinExists(nextOfKin.Id))
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
            return View(nextOfKin);
        }

        // GET: NextOfKins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NextOfKin == null)
            {
                return NotFound();
            }

            var nextOfKin = await _context.NextOfKin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nextOfKin == null)
            {
                return NotFound();
            }

            return View(nextOfKin);
        }

        // POST: NextOfKins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NextOfKin == null)
            {
                return Problem("Entity set 'ApplicationDbContext.NextOfKin'  is null.");
            }
            var nextOfKin = await _context.NextOfKin.FindAsync(id);
            if (nextOfKin != null)
            {
                _context.NextOfKin.Remove(nextOfKin);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NextOfKinExists(int id)
        {
          return (_context.NextOfKin?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
