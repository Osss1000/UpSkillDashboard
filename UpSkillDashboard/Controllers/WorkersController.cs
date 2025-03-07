using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UpSkillDashboard.Data;
using UpSkillDashboard.Models;

public class WorkersController : Controller
{
    private readonly ApplicationDbContext _context;

    public WorkersController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var workers = await _context.Workers.Include(w => w.User).ToListAsync();
        return View(workers);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(string name, string email, string phoneNumber, string nationalId, string profession, int? experience, decimal? hourlyRate, string address)
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
            Role = "Worker"
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        var worker = new Worker
        {
            UserId = user.UserId,
            NationalId = nationalId,
            Profession = profession,
            Experience = experience,
            HourlyRate = hourlyRate,
            Address = address
        };

        _context.Workers.Add(worker);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var worker = await _context.Workers.Include(w => w.User).FirstOrDefaultAsync(w => w.WorkerId == id);
        if (worker == null) return NotFound();

        return View(worker);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, string name, string email, string phoneNumber, string nationalId, string profession, int? experience, decimal? hourlyRate, string address)
    {
        var worker = await _context.Workers.Include(w => w.User).FirstOrDefaultAsync(w => w.WorkerId == id);
        if (worker == null) return NotFound();

        worker.User.Name = name;
        worker.User.Email = email;
        worker.User.PhoneNumber = phoneNumber;
        worker.NationalId = nationalId;
        worker.Profession = profession;
        worker.Experience = experience;
        worker.HourlyRate = hourlyRate;
        worker.Address = address;

        _context.Update(worker);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int id)
    {
        var worker = await _context.Workers.Include(w => w.User).FirstOrDefaultAsync(w => w.WorkerId == id);
        if (worker == null) return NotFound();

        return View(worker);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var worker = await _context.Workers.Include(w => w.User).FirstOrDefaultAsync(w => w.WorkerId == id);
        if (worker == null) return NotFound();

        _context.Users.Remove(worker.User);
        _context.Workers.Remove(worker);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
