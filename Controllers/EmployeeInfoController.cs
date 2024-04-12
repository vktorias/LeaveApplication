using LeaveApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeaveApplication.Controllers
{
    public class EmployeeInfoController : Controller
    {
        private readonly LeaveManagementDbContext _context;

        public EmployeeInfoController(LeaveManagementDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: EmployeeInfo/EmployeeLeave
        public IActionResult EmployeeLeave()
        {
            return View();
        }

        // POST: EmployeeInfo/EmployeeLeave
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EmployeeLeave(string firstName, string lastName)
        {
            var leaveForms = await _context.LeaveForms
                .Include(lf => lf.Employee)
                .Where(lf => lf.Employee.FirstName == firstName && lf.Employee.LastName == lastName)
                .ToListAsync();

            var leaveApplications = leaveForms
                .GroupBy(lf => $"{lf.Employee.FirstName} {lf.Employee.LastName}")
                .ToDictionary(group => group.Key, group => group.Select(lf => (lf.StartDate, lf.EndDate, lf.ApplicationDate)).ToList());

            ViewData["LeaveApplication"] = leaveApplications;

            return View();
        }
    }
}
