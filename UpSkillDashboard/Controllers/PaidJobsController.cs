using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UpSkillDashboard.Data;
using UpSkillDashboard.Models;

public class PaidJobsController : Controller
{
    private readonly ApplicationDbContext _context;

    public PaidJobsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // 🟢 INDEX: List all Paid Jobs
    public async Task<IActionResult> Index()
    {
        var jobs = await _context.PaidJobs
            .Include(j => j.Organization) // Fetch organization details
            .Where(j => j.Organization.OrganizationRole == (int)OrganizationRoleEnum.ForProfit) // ✅ Enum comparison
            .ToListAsync();

        return View(jobs);
    }

    // 🟢 DETAILS: View job details including applications
    public async Task<IActionResult> Details(int id)
    {
        var job = await _context.PaidJobs
            .Include(j => j.Organization)
            .Include(j => j.WorkerApplications)
                .ThenInclude(wa => wa.ApplicationStatus)
            .Include(j => j.WorkerApplications)
                .ThenInclude(wa => wa.Worker)
                    .ThenInclude(w => w.User) // ✅ If you need user details (e.g., Name, Email)
            .FirstOrDefaultAsync(j => j.PaidJobId == id && j.Organization.OrganizationRole == (int)OrganizationRoleEnum.ForProfit);

        if (job == null)
            return NotFound();

        // ✅ Fetch approved applications count directly from the DB
        int approvedApplicationsCount = await _context.WorkerApplications
            .Where(w => w.PaidJobId == id && w.ApplicationStatus.Status == (int)ApplicationStatusEnum.Approved)
            .CountAsync();

        // ✅ Determine job status
        ViewBag.JobStatus = (job.IsManuallyClosed || approvedApplicationsCount >= job.NumberOfPeopleNeeded)
            ? "Closed"
            : "Open";

        return View(job);
    }

    // 🟢 DELETE CONFIRMATION PAGE: Shows delete confirmation
    public async Task<IActionResult> Delete(int id)
    {
        var job = await _context.PaidJobs
            .Include(j => j.Organization)
            .FirstOrDefaultAsync(j => j.PaidJobId == id && j.Organization.OrganizationRole == (int)OrganizationRoleEnum.ForProfit);

        if (job == null)
            return NotFound();

        return View(job);
    }

    // 🟢 DELETE JOB: Permanently deletes the job
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var job = await _context.PaidJobs.FindAsync(id);


        _context.PaidJobs.Remove(job);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    // 🟢 CLOSE JOB: Allows organizations to manually close a job
    [HttpPost]
    public async Task<IActionResult> CloseJob(int id)
    {
        var job = await _context.PaidJobs
            .Include(j => j.Organization)
            .FirstOrDefaultAsync(j => j.PaidJobId == id && j.Organization.OrganizationRole == (int)OrganizationRoleEnum.ForProfit); if (job == null) return NotFound(); if (job == null) return NotFound();

        job.IsManuallyClosed = true;
        _context.Update(job);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Details), new { id });
    }

    // 🟢 REOPEN JOB: Allows organizations to manually reopen a job
    [HttpPost]
    public async Task<IActionResult> ReopenJob(int id)
    {
        var job = await _context.PaidJobs
            .Include(j => j.Organization)
            .FirstOrDefaultAsync(j => j.PaidJobId == id && j.Organization.OrganizationRole == (int)OrganizationRoleEnum.ForProfit); if (job == null) return NotFound(); if (job == null) return NotFound();

        job.IsManuallyClosed = false;
        _context.Update(job);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Details), new { id });
    }
}
