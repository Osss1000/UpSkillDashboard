using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using UpSkillDashboard.Data;
using UpSkillDashboard.Models;

namespace UpSkillDashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var totalUsers = await _context.Users.CountAsync();
            var totalWorkers = await _context.Workers.CountAsync();
            var totalClients = await _context.Clients.CountAsync();
            var totalOrganizations = await _context.Organizations.CountAsync();
            var totalProfitOrganizations = await _context.Organizations
                .Where(o => o.OrganizationRole == OrganizationRoleEnum.ForProfit)
                .CountAsync();
            var totalVolunteeringOrganizations = totalOrganizations - totalProfitOrganizations; 

            var recentClients = await _context.Clients
                .Include(c => c.User)
                .OrderByDescending(c => c.CreatedDate)
                .Take(5)
                .ToListAsync();

            var recentWorkers = await _context.Workers
                .Include(w => w.User)
                .OrderByDescending(w => w.CreatedDate)
                .Take(5)
                .ToListAsync();

            var recentOrganizations = await _context.Organizations
                .Include(o => o.User)
                .OrderByDescending(o => o.CreatedDate)
                .Take(5)
                .ToListAsync();

            ViewData["TotalUsers"] = totalUsers;
            ViewData["TotalWorkers"] = totalWorkers;
            ViewData["TotalClients"] = totalClients;
            ViewData["TotalOrganizations"] = totalOrganizations;
            ViewData["TotalProfitOrganizations"] = totalProfitOrganizations;
            ViewData["TotalVolunteeringOrganizations"] = totalVolunteeringOrganizations;
            ViewData["RecentClients"] = recentClients;
            ViewData["RecentWorkers"] = recentWorkers;
            ViewData["RecentOrganizations"] = recentOrganizations;

            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetGrowthChartData()
        {
            var startDate = DateTime.UtcNow.AddMonths(-6); 

            var userGrowth = await _context.Users
                .Where(u => u.CreatedDate >= startDate)
                .GroupBy(u => new { u.CreatedDate.Year, u.CreatedDate.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Count = g.Count()
                }).ToListAsync();

            var paidJobGrowth = await _context.PaidJobs
                .Where(j => j.CreatedDate >= startDate)
                .GroupBy(j => new { j.CreatedDate.Year, j.CreatedDate.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Count = g.Count()
                }).ToListAsync();

            var volunteerJobGrowth = await _context.VolunteeringJobs
                .Where(j => j.CreatedDate >= startDate)
                .GroupBy(j => new { j.CreatedDate.Year, j.CreatedDate.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Count = g.Count()
                }).ToListAsync();

            return Json(new { userGrowth, paidJobGrowth, volunteerJobGrowth });
        }
    }
}
