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
    public class LeaveRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeaveRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LeaveRequests
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LeaveRequest.Include(l => l.LeaveAllowance);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LeaveRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LeaveRequest == null)
            {
                return NotFound();
            }

            var leaveRequest = await _context.LeaveRequest
                .Include(l => l.LeaveAllowance)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveRequest == null)
            {
                return NotFound();
            }

            return View(leaveRequest);
        }

        // GET: LeaveRequests/Create
        public IActionResult Create()
        {
            ViewData["LeaveAllowanceID"] = new SelectList(_context.Set<LeaveAllowance>(), "Id", "Id");
            return View();
        }

        // POST: LeaveRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StaffNo,LeaveDaysAvailable,LeaveStartDate,NoOfDays,LeaveAllowanceID,AllowanceAmount,ReasonForLeave")] LeaveRequest leaveRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leaveRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LeaveAllowanceID"] = new SelectList(_context.Set<LeaveAllowance>(), "Id", "Id", leaveRequest.LeaveAllowanceID);
            return View(leaveRequest);
        }

        // GET: LeaveRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LeaveRequest == null)
            {
                return NotFound();
            }

            var leaveRequest = await _context.LeaveRequest.FindAsync(id);
            if (leaveRequest == null)
            {
                return NotFound();
            }
            ViewData["LeaveAllowanceID"] = new SelectList(_context.Set<LeaveAllowance>(), "Id", "Id", leaveRequest.LeaveAllowanceID);
            return View(leaveRequest);
        }

        // POST: LeaveRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StaffNo,LeaveDaysAvailable,LeaveStartDate,NoOfDays,LeaveAllowanceID,AllowanceAmount,ReasonForLeave")] LeaveRequest leaveRequest)
        {
            if (id != leaveRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaveRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveRequestExists(leaveRequest.Id))
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
            ViewData["LeaveAllowanceID"] = new SelectList(_context.Set<LeaveAllowance>(), "Id", "Id", leaveRequest.LeaveAllowanceID);
            return View(leaveRequest);
        }

        // GET: LeaveRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LeaveRequest == null)
            {
                return NotFound();
            }

            var leaveRequest = await _context.LeaveRequest
                .Include(l => l.LeaveAllowance)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveRequest == null)
            {
                return NotFound();
            }

            return View(leaveRequest);
        }

        // POST: LeaveRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LeaveRequest == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LeaveRequest'  is null.");
            }
            var leaveRequest = await _context.LeaveRequest.FindAsync(id);
            if (leaveRequest != null)
            {
                _context.LeaveRequest.Remove(leaveRequest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveRequestExists(int id)
        {
          return (_context.LeaveRequest?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
