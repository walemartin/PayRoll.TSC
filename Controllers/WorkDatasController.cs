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
    public class WorkDatasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WorkDatas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.WorkData.Include(w => w.BankBranch).Include(w => w.JobTitle).Include(w => w.LeaveType).Include(w => w.NHF).Include(w => w.Pension);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: WorkDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WorkData == null)
            {
                return NotFound();
            }

            var workData = await _context.WorkData
                .Include(w => w.BankBranch)
                .Include(w => w.JobTitle)
                .Include(w => w.LeaveType)
                .Include(w => w.NHF)
                .Include(w => w.Pension)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workData == null)
            {
                return NotFound();
            }

            return View(workData);
        }

        // GET: WorkDatas/Create
        public IActionResult Create()
        {
            ViewData["BankBranchID"] = new SelectList(_context.BankBranch, "ID", "ID");
            ViewData["JobTitleID"] = new SelectList(_context.JobTitle, "ID", "ID");
            ViewData["LeaveTypeID"] = new SelectList(_context.LeaveType, "Id", "Id");
            ViewData["NHFID"] = new SelectList(_context.NHF, "Id", "Id");
            ViewData["PensionID"] = new SelectList(_context.Pension, "Id", "Id");
            return View();
        }

        // POST: WorkDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StaffNo,HireDate,EmployeeType,JobTitleID,BankBranchID,Currency,Salary,PensionID,NHFID,NHISMonthlyAmt,LeaveTypeID,PostedDate")] WorkData workData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BankBranchID"] = new SelectList(_context.BankBranch, "ID", "ID", workData.BankBranchID);
            ViewData["JobTitleID"] = new SelectList(_context.JobTitle, "ID", "ID", workData.JobTitleID);
            ViewData["LeaveTypeID"] = new SelectList(_context.LeaveType, "Id", "Id", workData.LeaveTypeID);
            ViewData["NHFID"] = new SelectList(_context.NHF, "Id", "Id", workData.NHFID);
            ViewData["PensionID"] = new SelectList(_context.Pension, "Id", "Id", workData.PensionID);
            return View(workData);
        }

        // GET: WorkDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WorkData == null)
            {
                return NotFound();
            }

            var workData = await _context.WorkData.FindAsync(id);
            if (workData == null)
            {
                return NotFound();
            }
            ViewData["BankBranchID"] = new SelectList(_context.BankBranch, "ID", "ID", workData.BankBranchID);
            ViewData["JobTitleID"] = new SelectList(_context.JobTitle, "ID", "ID", workData.JobTitleID);
            ViewData["LeaveTypeID"] = new SelectList(_context.LeaveType, "Id", "Id", workData.LeaveTypeID);
            ViewData["NHFID"] = new SelectList(_context.NHF, "Id", "Id", workData.NHFID);
            ViewData["PensionID"] = new SelectList(_context.Pension, "Id", "Id", workData.PensionID);
            return View(workData);
        }

        // POST: WorkDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StaffNo,HireDate,EmployeeType,JobTitleID,BankBranchID,Currency,Salary,PensionID,NHFID,NHISMonthlyAmt,LeaveTypeID,PostedDate")] WorkData workData)
        {
            if (id != workData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkDataExists(workData.Id))
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
            ViewData["BankBranchID"] = new SelectList(_context.BankBranch, "ID", "ID", workData.BankBranchID);
            ViewData["JobTitleID"] = new SelectList(_context.JobTitle, "ID", "ID", workData.JobTitleID);
            ViewData["LeaveTypeID"] = new SelectList(_context.LeaveType, "Id", "Id", workData.LeaveTypeID);
            ViewData["NHFID"] = new SelectList(_context.NHF, "Id", "Id", workData.NHFID);
            ViewData["PensionID"] = new SelectList(_context.Pension, "Id", "Id", workData.PensionID);
            return View(workData);
        }

        // GET: WorkDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WorkData == null)
            {
                return NotFound();
            }

            var workData = await _context.WorkData
                .Include(w => w.BankBranch)
                .Include(w => w.JobTitle)
                .Include(w => w.LeaveType)
                .Include(w => w.NHF)
                .Include(w => w.Pension)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workData == null)
            {
                return NotFound();
            }

            return View(workData);
        }

        // POST: WorkDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WorkData == null)
            {
                return Problem("Entity set 'ApplicationDbContext.WorkData'  is null.");
            }
            var workData = await _context.WorkData.FindAsync(id);
            if (workData != null)
            {
                _context.WorkData.Remove(workData);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkDataExists(int id)
        {
          return (_context.WorkData?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
