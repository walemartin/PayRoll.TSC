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
    public class SalaryBreakdownsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalaryBreakdownsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SalaryBreakdowns
        public async Task<IActionResult> Index()
        {
              return _context.SalaryBreakdown != null ? 
                          View(await _context.SalaryBreakdown.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.SalaryBreakdown'  is null.");
        }

        // GET: SalaryBreakdowns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SalaryBreakdown == null)
            {
                return NotFound();
            }

            var salaryBreakdown = await _context.SalaryBreakdown
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salaryBreakdown == null)
            {
                return NotFound();
            }

            return View(salaryBreakdown);
        }

        // GET: SalaryBreakdowns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalaryBreakdowns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Category,BasicPercentage")] SalaryBreakdown salaryBreakdown)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salaryBreakdown);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salaryBreakdown);
        }

        // GET: SalaryBreakdowns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SalaryBreakdown == null)
            {
                return NotFound();
            }

            var salaryBreakdown = await _context.SalaryBreakdown.FindAsync(id);
            if (salaryBreakdown == null)
            {
                return NotFound();
            }
            return View(salaryBreakdown);
        }

        // POST: SalaryBreakdowns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Category,BasicPercentage")] SalaryBreakdown salaryBreakdown)
        {
            if (id != salaryBreakdown.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salaryBreakdown);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalaryBreakdownExists(salaryBreakdown.Id))
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
            return View(salaryBreakdown);
        }

        // GET: SalaryBreakdowns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SalaryBreakdown == null)
            {
                return NotFound();
            }

            var salaryBreakdown = await _context.SalaryBreakdown
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salaryBreakdown == null)
            {
                return NotFound();
            }

            return View(salaryBreakdown);
        }

        // POST: SalaryBreakdowns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SalaryBreakdown == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SalaryBreakdown'  is null.");
            }
            var salaryBreakdown = await _context.SalaryBreakdown.FindAsync(id);
            if (salaryBreakdown != null)
            {
                _context.SalaryBreakdown.Remove(salaryBreakdown);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaryBreakdownExists(int id)
        {
          return (_context.SalaryBreakdown?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
