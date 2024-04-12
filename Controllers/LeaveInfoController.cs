using LeaveApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeaveApplication.Controllers
{
    public class LeaveInfoController : Controller
    {
        private readonly LeaveManagementDbContext _context;

        public LeaveInfoController(LeaveManagementDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ApplicationByMonth()
        {
            return View();
        }
        // GET: LeaveInfo/ApplicationsByMonth
        public async Task<IActionResult> ApplicationsByMonth(int year, int month)
        {
            int defaultMonth = DateTime.Today.Month;
            int defaultYear = DateTime.Today.Year;

            // Skapa en DateTime-objekt för den första dagen i den angivna månaden
            var startDate = new DateTime(year, month, 1);

            // Skapa en DateTime-objekt för den sista dagen i den angivna månaden
            var endDate = startDate.AddMonths(1).AddDays(-1);

            // Hämta ansökningar som överlappar den valda månaden
            var applications = await _context.LeaveForms
                .Include(lf => lf.Employee)
                .Where(lf => (lf.StartDate <= endDate && lf.EndDate >= startDate))
                .ToListAsync();
            // Utskrift för att felsöka
            foreach (var app in applications)
            {
                Console.WriteLine($"Start Date: {app.StartDate}, End Date: {app.EndDate}, Employee: {app.Employee.FirstName} {app.Employee.LastName}");
            }
            // Skapa en dictionary för att hålla reda på antalet dagar varje person har sökt ledighet
            // Skapa en dictionary för att hålla reda på ansökningarna per anställd
            var leaveApplications = new Dictionary<string, List<(DateTime, DateTime, DateTime, int)>>();

            // Loopa igenom varje ansökan och lägg till den i dictionary
            foreach (var application in applications)
            {
                var employeeName = $"{application.Employee.FirstName} {application.Employee.LastName}";
                if (!leaveApplications.ContainsKey(employeeName))
                {
                    leaveApplications[employeeName] = new List<(DateTime, DateTime, DateTime, int)>();
                }

                // Beräkna antalet dagar för ansökan
                int numberOfDays = (application.EndDate - application.StartDate).Days + 1;

                leaveApplications[employeeName].Add((application.StartDate, application.EndDate, application.ApplicationDate, numberOfDays));
            }

            // Skicka data till vyn
            ViewData["LeaveApplications"] = leaveApplications;
            ViewBag.SelectedMonth = month;
            ViewBag.SelectedYear = year;

            return View("ApplicationByMonth");
        }
    }
}
