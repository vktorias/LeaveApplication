using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveApplication.Data;
using LeaveApplication.Models;

namespace LeaveApplication.Controllers
{
    public class LeaveFormsController : Controller
    {
        private readonly LeaveManagementDbContext _context;

        public LeaveFormsController(LeaveManagementDbContext context)
        {
            _context = context;
        }

        // GET: LeaveForms
        public async Task<IActionResult> Index()
        {
            var leaveManagementDbContext = _context.LeaveForms.Include(l => l.Employee);
            return View(await leaveManagementDbContext.ToListAsync());
        }

        // GET: LeaveForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveForm = await _context.LeaveForms
                .Include(l => l.Employee)
                .FirstOrDefaultAsync(m => m.LeaveApplicationId == id);
            if (leaveForm == null)
            {
                return NotFound();
            }

            return View(leaveForm);
        }

        // GET: LeaveForms/Create
        public IActionResult Create()
        {
            ViewBag.Employees = _context.Employees.ToList();
            return View();
        }

        // POST: LeaveForms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeaveFormId,StartDate,EndDate,Type,FkEmployeeId")] LeaveForm leaveForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leaveForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName", leaveForm.FkEmployeeId);
            return View(leaveForm);
        }

        // GET: LeaveForms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveForm = await _context.LeaveForms.FindAsync(id);
            if (leaveForm == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", leaveForm.FkEmployeeId);
            return View(leaveForm);
        }

        // POST: LeaveForms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LeaveApplicationId,StartDate,EndDate,Type,ApplicationDate,EmployeeId")] LeaveForm leaveForm)
        {
            if (id != leaveForm.LeaveApplicationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaveForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveFormExists(leaveForm.LeaveApplicationId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", leaveForm.FkEmployeeId);
            return View(leaveForm);
        }

        // GET: LeaveForms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveForm = await _context.LeaveForms
                .Include(l => l.Employee)
                .FirstOrDefaultAsync(m => m.LeaveApplicationId == id);
            if (leaveForm == null)
            {
                return NotFound();
            }

            return View(leaveForm);
        }

        // POST: LeaveForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaveForm = await _context.LeaveForms.FindAsync(id);
            if (leaveForm != null)
            {
                _context.LeaveForms.Remove(leaveForm);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveFormExists(int id)
        {
            return _context.LeaveForms.Any(e => e.LeaveApplicationId == id);
        }
    }
}
