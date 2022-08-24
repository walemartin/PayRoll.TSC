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
    public class NHFsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NHFsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NHFs
        public async Task<IActionResult> Index()
        {
              return _context.NHF != null ? 
                          View(await _context.NHF.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.NHF'  is null.");
        }

        // GET: NHFs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NHF == null)
            {
                return NotFound();
            }

            var nHF = await _context.NHF
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nHF == null)
            {
                return NotFound();
            }

            return View(nHF);
        }

        // GET: NHFs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NHFs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Question,NHFpercentage")] NHF nHF)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nHF);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nHF);
        }

        // GET: NHFs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NHF == null)
            {
                return NotFound();
            }

            var nHF = await _context.NHF.FindAsync(id);
            if (nHF == null)
            {
                return NotFound();
            }
            return View(nHF);
        }

        // POST: NHFs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Question,NHFpercentage")] NHF nHF)
        {
            if (id != nHF.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nHF);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NHFExists(nHF.Id))
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
            return View(nHF);
        }

        // GET: NHFs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NHF == null)
            {
                return NotFound();
            }

            var nHF = await _context.NHF
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nHF == null)
            {
                return NotFound();
            }

            return View(nHF);
        }

        // POST: NHFs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NHF == null)
            {
                return Problem("Entity set 'ApplicationDbContext.NHF'  is null.");
            }
            var nHF = await _context.NHF.FindAsync(id);
            if (nHF != null)
            {
                _context.NHF.Remove(nHF);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NHFExists(int id)
        {
          return (_context.NHF?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
