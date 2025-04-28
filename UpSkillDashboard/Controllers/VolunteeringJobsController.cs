using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UpSkillDashboard.Data;
using UpSkillDashboard.Models;

public class VolunteeringJobsController : Controller
{
    private readonly ApplicationDbContext _context;

    public VolunteeringJobsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // 🟢 INDEX: List all Volunteering Jobs (Only from Voluntary Organizations)
    public async Task<IActionResult> Index()
    {
        var jobs = await _context.VolunteeringJobs
            .Include(j => j.Organization)
            .ToListAsync();

        return View(jobs);
    }

    // 🟢 DETAILS: View job details including applications
    public async Task<IActionResult> Details(int id)
    {
        var job = await _context.VolunteeringJobs
            .Include(j => j.Organization)
            .Include(j => j.VolunteeringApplications)
                .ThenInclude(va => va.ApplicationStatus)
            .Include(j => j.VolunteeringApplications)
                .ThenInclude(va => va.Worker)
            .Include(j => j.VolunteeringApplications)
                .ThenInclude(va => va.Client)
            .FirstOrDefaultAsync(j => j.VolunteeringJobId == id );

        if (job == null)
            return NotFound();

        return View(job);
    }

    // 🟢 DELETE: Show delete confirmation
    public async Task<IActionResult> Delete(int id)
    {
        var job = await _context.VolunteeringJobs
            .Include(j => j.Organization)
            .FirstOrDefaultAsync(j => j.VolunteeringJobId == id );

        if (job == null) return NotFound();
        return View(job);
    }

    // 🟢 DELETE CONFIRMED: Permanently delete the job
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var job = await _context.VolunteeringJobs.FindAsync(id);
        if (job == null) return NotFound();

        _context.VolunteeringJobs.Remove(job);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
