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
    public class NationalitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NationalitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Nationalities
        public async Task<IActionResult> Index()
        {
              return _context.Nationality != null ? 
                          View(await _context.Nationality.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Nationality'  is null.");
        }

        // GET: Nationalities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Nationality == null)
            {
                return NotFound();
            }

            var nationality = await _context.Nationality
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nationality == null)
            {
                return NotFound();
            }

            return View(nationality);
        }

        // GET: Nationalities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nationalities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Nationality nationality)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nationality);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nationality);
        }

        // GET: Nationalities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Nationality == null)
            {
                return NotFound();
            }

            var nationality = await _context.Nationality.FindAsync(id);
            if (nationality == null)
            {
                return NotFound();
            }
            return View(nationality);
        }

        // POST: Nationalities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Nationality nationality)
        {
            if (id != nationality.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nationality);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NationalityExists(nationality.ID))
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
            return View(nationality);
        }

        // GET: Nationalities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Nationality == null)
            {
                return NotFound();
            }

            var nationality = await _context.Nationality
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nationality == null)
            {
                return NotFound();
            }

            return View(nationality);
        }

        // POST: Nationalities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Nationality == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Nationality'  is null.");
            }
            var nationality = await _context.Nationality.FindAsync(id);
            if (nationality != null)
            {
                _context.Nationality.Remove(nationality);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NationalityExists(int id)
        {
          return (_context.Nationality?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
