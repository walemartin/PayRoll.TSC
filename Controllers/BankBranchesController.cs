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
    public class BankBranchesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BankBranchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BankBranches
        public async Task<IActionResult> Index()
        {
              return _context.BankBranch != null ? 
                          View(await _context.BankBranch.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.BankBranch'  is null.");
        }

        // GET: BankBranches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BankBranch == null)
            {
                return NotFound();
            }

            var bankBranch = await _context.BankBranch
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bankBranch == null)
            {
                return NotFound();
            }

            return View(bankBranch);
        }

        // GET: BankBranches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BankBranches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] BankBranch bankBranch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bankBranch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bankBranch);
        }

        // GET: BankBranches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BankBranch == null)
            {
                return NotFound();
            }

            var bankBranch = await _context.BankBranch.FindAsync(id);
            if (bankBranch == null)
            {
                return NotFound();
            }
            return View(bankBranch);
        }

        // POST: BankBranches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] BankBranch bankBranch)
        {
            if (id != bankBranch.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bankBranch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BankBranchExists(bankBranch.ID))
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
            return View(bankBranch);
        }

        // GET: BankBranches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BankBranch == null)
            {
                return NotFound();
            }

            var bankBranch = await _context.BankBranch
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bankBranch == null)
            {
                return NotFound();
            }

            return View(bankBranch);
        }

        // POST: BankBranches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BankBranch == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BankBranch'  is null.");
            }
            var bankBranch = await _context.BankBranch.FindAsync(id);
            if (bankBranch != null)
            {
                _context.BankBranch.Remove(bankBranch);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BankBranchExists(int id)
        {
          return (_context.BankBranch?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
