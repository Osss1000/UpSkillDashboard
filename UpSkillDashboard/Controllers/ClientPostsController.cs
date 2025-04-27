using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UpSkillDashboard.Data;
using UpSkillDashboard.Models;

public class ClientPostsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ClientPostsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // 🟢 INDEX: List all Client Posts with Client User details
    public async Task<IActionResult> Index()
    {
        var posts = await _context.ClientPosts
            .Include(p => p.Client)
                .ThenInclude(c => c.User) // ✅ Ensure Client's User details are included
            .ToListAsync();

        return View(posts);
    }

    // 🟢 DETAILS: View post details including worker applications
    public async Task<IActionResult> Details(int id)
    {
        var post = await _context.ClientPosts
            .Include(p => p.Client)
                .ThenInclude(c => c.User) // ✅ Ensure Client's User details are included
            .Include(p => p.WorkerApplications)
                .ThenInclude(wa => wa.ApplicationStatus)
            .Include(p => p.WorkerApplications)
                .ThenInclude(wa => wa.Worker)
                    .ThenInclude(w => w.User)
            .FirstOrDefaultAsync(p => p.ClientPostId == id);

        if (post == null)
            return NotFound();

        return View(post);
    }

    // 🟢 DELETE: Show delete confirmation
    public async Task<IActionResult> Delete(int id)
    {
        var post = await _context.ClientPosts
            .Include(p => p.Client)
                .ThenInclude(c => c.User) // ✅ Include User details to show client name
            .FirstOrDefaultAsync(p => p.ClientPostId == id);

        if (post == null) return NotFound();
        return View(post);
    }

    // 🟢 DELETE CONFIRMED: Permanently delete the post
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var post = await _context.ClientPosts.FindAsync(id);
        if (post == null) return NotFound();

        _context.ClientPosts.Remove(post);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}