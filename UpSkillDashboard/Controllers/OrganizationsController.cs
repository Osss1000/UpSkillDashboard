using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UpSkillDashboard.Data;
using UpSkillDashboard.Models;

public class OrganizationsController : Controller
{
    private readonly ApplicationDbContext _context;

    public OrganizationsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var organizations = await _context.Organizations.Include(o => o.User).ToListAsync();
        return View(organizations);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(string name, string email, string phoneNumber, string organizationName, OrganizationRoleEnum organizationType)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        var user = new User
        {
            Name = name,
            Email = email,
            PhoneNumber = phoneNumber,
            Role = "Organization"
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        var organization = new Organization
        {
            UserId = user.UserId,
            Name = organizationName,
            OrganizationRole = organizationType
        };

        _context.Organizations.Add(organization);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var organization = await _context.Organizations.Include(o => o.User).FirstOrDefaultAsync(o => o.OrganizationId == id);
        if (organization == null) return NotFound();

        return View(organization);
    }

    public async Task<IActionResult> Details(int id)
    {
        var organization = await _context.Organizations.Include(o => o.User).FirstOrDefaultAsync(o => o.OrganizationId == id);
        if (organization == null) return NotFound();

        return View(organization);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var organization = await _context.Organizations.Include(o => o.User).FirstOrDefaultAsync(o => o.OrganizationId == id);
        if (organization == null) return NotFound();

        _context.Users.Remove(organization.User);
        _context.Organizations.Remove(organization);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
