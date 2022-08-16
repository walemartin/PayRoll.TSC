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
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Employees.Include(e => e.MaritalStatus).Include(e => e.Nationality).Include(e => e.StateOfOrigin).Include(e => e.Title);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employees = await _context.Employees
                .Include(e => e.MaritalStatus)
                .Include(e => e.Nationality)
                .Include(e => e.StateOfOrigin)
                .Include(e => e.Title)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employees == null)
            {
                return NotFound();
            }

            return View(employees);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["MaritalStatusID"] = new SelectList(_context.Set<MaritalStatus>(), "ID", "ID");
            ViewData["NationalityID"] = new SelectList(_context.Set<Nationality>(), "ID", "ID");
            ViewData["StateOfOriginID"] = new SelectList(_context.Set<StateOfOrigin>(), "ID", "ID");
            ViewData["TitleID"] = new SelectList(_context.Set<Title>(), "ID", "ID");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StaffNo,TitleID,EmployeeName,Gender,DateOfBirth,PhoneNumber,Email,Address,MaritalStatusID,StateOfOriginID,NationalityID,PostedDate")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employees);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaritalStatusID"] = new SelectList(_context.Set<MaritalStatus>(), "ID", "ID", employees.MaritalStatusID);
            ViewData["NationalityID"] = new SelectList(_context.Set<Nationality>(), "ID", "ID", employees.NationalityID);
            ViewData["StateOfOriginID"] = new SelectList(_context.Set<StateOfOrigin>(), "ID", "ID", employees.StateOfOriginID);
            ViewData["TitleID"] = new SelectList(_context.Set<Title>(), "ID", "ID", employees.TitleID);
            return View(employees);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employees = await _context.Employees.FindAsync(id);
            if (employees == null)
            {
                return NotFound();
            }
            ViewData["MaritalStatusID"] = new SelectList(_context.Set<MaritalStatus>(), "ID", "ID", employees.MaritalStatusID);
            ViewData["NationalityID"] = new SelectList(_context.Set<Nationality>(), "ID", "ID", employees.NationalityID);
            ViewData["StateOfOriginID"] = new SelectList(_context.Set<StateOfOrigin>(), "ID", "ID", employees.StateOfOriginID);
            ViewData["TitleID"] = new SelectList(_context.Set<Title>(), "ID", "ID", employees.TitleID);
            return View(employees);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StaffNo,TitleID,EmployeeName,Gender,DateOfBirth,PhoneNumber,Email,Address,MaritalStatusID,StateOfOriginID,NationalityID,PostedDate")] Employees employees)
        {
            if (id != employees.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employees);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeesExists(employees.Id))
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
            ViewData["MaritalStatusID"] = new SelectList(_context.Set<MaritalStatus>(), "ID", "ID", employees.MaritalStatusID);
            ViewData["NationalityID"] = new SelectList(_context.Set<Nationality>(), "ID", "ID", employees.NationalityID);
            ViewData["StateOfOriginID"] = new SelectList(_context.Set<StateOfOrigin>(), "ID", "ID", employees.StateOfOriginID);
            ViewData["TitleID"] = new SelectList(_context.Set<Title>(), "ID", "ID", employees.TitleID);
            return View(employees);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employees = await _context.Employees
                .Include(e => e.MaritalStatus)
                .Include(e => e.Nationality)
                .Include(e => e.StateOfOrigin)
                .Include(e => e.Title)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employees == null)
            {
                return NotFound();
            }

            return View(employees);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Employees == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Employees'  is null.");
            }
            var employees = await _context.Employees.FindAsync(id);
            if (employees != null)
            {
                _context.Employees.Remove(employees);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeesExists(int id)
        {
          return (_context.Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
