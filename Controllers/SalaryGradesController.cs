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
    public class SalaryGradesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalaryGradesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SalaryGrades
        public async Task<IActionResult> Index()
        {
              return _context.SalaryGrade != null ? 
                          View(await _context.SalaryGrade.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.SalaryGrade'  is null.");
        }

        // GET: SalaryGrades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SalaryGrade == null)
            {
                return NotFound();
            }

            var salaryGrade = await _context.SalaryGrade
                .FirstOrDefaultAsync(m => m.ID == id);
            if (salaryGrade == null)
            {
                return NotFound();
            }

            return View(salaryGrade);
        }

        // GET: SalaryGrades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalaryGrades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] SalaryGrade salaryGrade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salaryGrade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salaryGrade);
        }

        // GET: SalaryGrades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SalaryGrade == null)
            {
                return NotFound();
            }

            var salaryGrade = await _context.SalaryGrade.FindAsync(id);
            if (salaryGrade == null)
            {
                return NotFound();
            }
            return View(salaryGrade);
        }

        // POST: SalaryGrades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] SalaryGrade salaryGrade)
        {
            if (id != salaryGrade.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salaryGrade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalaryGradeExists(salaryGrade.ID))
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
            return View(salaryGrade);
        }

        // GET: SalaryGrades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SalaryGrade == null)
            {
                return NotFound();
            }

            var salaryGrade = await _context.SalaryGrade
                .FirstOrDefaultAsync(m => m.ID == id);
            if (salaryGrade == null)
            {
                return NotFound();
            }

            return View(salaryGrade);
        }

        // POST: SalaryGrades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SalaryGrade == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SalaryGrade'  is null.");
            }
            var salaryGrade = await _context.SalaryGrade.FindAsync(id);
            if (salaryGrade != null)
            {
                _context.SalaryGrade.Remove(salaryGrade);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaryGradeExists(int id)
        {
          return (_context.SalaryGrade?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
