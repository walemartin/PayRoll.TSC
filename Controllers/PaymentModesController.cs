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
    public class PaymentModesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaymentModesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PaymentModes
        public async Task<IActionResult> Index()
        {
              return _context.PaymentMode != null ? 
                          View(await _context.PaymentMode.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.PaymentMode'  is null.");
        }

        // GET: PaymentModes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PaymentMode == null)
            {
                return NotFound();
            }

            var paymentMode = await _context.PaymentMode
                .FirstOrDefaultAsync(m => m.ID == id);
            if (paymentMode == null)
            {
                return NotFound();
            }

            return View(paymentMode);
        }

        // GET: PaymentModes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaymentModes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] PaymentMode paymentMode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paymentMode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paymentMode);
        }

        // GET: PaymentModes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PaymentMode == null)
            {
                return NotFound();
            }

            var paymentMode = await _context.PaymentMode.FindAsync(id);
            if (paymentMode == null)
            {
                return NotFound();
            }
            return View(paymentMode);
        }

        // POST: PaymentModes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] PaymentMode paymentMode)
        {
            if (id != paymentMode.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentMode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentModeExists(paymentMode.ID))
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
            return View(paymentMode);
        }

        // GET: PaymentModes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PaymentMode == null)
            {
                return NotFound();
            }

            var paymentMode = await _context.PaymentMode
                .FirstOrDefaultAsync(m => m.ID == id);
            if (paymentMode == null)
            {
                return NotFound();
            }

            return View(paymentMode);
        }

        // POST: PaymentModes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PaymentMode == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PaymentMode'  is null.");
            }
            var paymentMode = await _context.PaymentMode.FindAsync(id);
            if (paymentMode != null)
            {
                _context.PaymentMode.Remove(paymentMode);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentModeExists(int id)
        {
          return (_context.PaymentMode?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
