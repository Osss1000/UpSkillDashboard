using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UpSkillDashboard.Data;
using UpSkillDashboard.Models;
using System.Threading.Tasks;
using System.Linq;

public class ClientsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ClientsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var clients = await _context.Clients.Include(c => c.User).ToListAsync();
        return View(clients);
    }

    // CREATE CLIENT - GET
    public IActionResult Create()
    {
        return View();
    }

    // CREATE CLIENT - POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(string name, string email, string phoneNumber, string nationalId, string address)
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
            Role = "Client"
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        var client = new Client
        {
            UserId = user.UserId,
            NationalId = nationalId,
            Address = address
        };

        _context.Clients.Add(client);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    // EDIT CLIENT - GET
    public async Task<IActionResult> Edit(int id)
    {
        var client = await _context.Clients.Include(c => c.User).FirstOrDefaultAsync(c => c.ClientId == id);
        if (client == null) return NotFound();

        return View(client);
    }

    // EDIT CLIENT - POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, string name, string email, string phoneNumber, string nationalId, string address)
    {
        var client = await _context.Clients.Include(c => c.User).FirstOrDefaultAsync(c => c.ClientId == id);
        if (client == null) return NotFound();

        client.User.Name = name;
        client.User.Email = email;
        client.User.PhoneNumber = phoneNumber;
        client.NationalId = nationalId;
        client.Address = address;

        _context.Update(client);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    // DETAILS CLIENT
    public async Task<IActionResult> Details(int id)
    {
        var client = await _context.Clients.Include(c => c.User).FirstOrDefaultAsync(c => c.ClientId == id);
        if (client == null) return NotFound();

        return View(client);
    }

    // DELETE CLIENT
    public async Task<IActionResult> Delete(int id)
    {
        var client = await _context.Clients.Include(c => c.User).FirstOrDefaultAsync(c => c.ClientId == id);
        if (client == null) return NotFound();

        _context.Users.Remove(client.User);
        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
