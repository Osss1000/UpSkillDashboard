using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UpSkillDashboard.Data;
using UpSkillDashboard.Models;

namespace UpSkillDashboard.Controllers
{
    public class AdvertisementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdvertisementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Advertisements/Index/{sponsorId}
        public async Task<IActionResult> Index(int sponsorId)
        {
            var advertisements = await _context.Advertisements
                .Include(a => a.Sponsor)
                .Where(a => a.SponsorId == sponsorId)
                .ToListAsync();

            ViewBag.SponsorId = sponsorId; // Pass SponsorId for later use in views

            return View(advertisements);
        }

        // GET: Advertisements/Create
        public IActionResult Create(int sponsorId)
        {
            ViewBag.SponsorId = sponsorId;
            return View();
        }

        // POST: Advertisements/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Advertisement advertisement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(advertisement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { sponsorId = advertisement.SponsorId });
            }

            ViewBag.SponsorId = advertisement.SponsorId;
            return View(advertisement);
        }

        // GET: Advertisements/Details/{id}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisement = await _context.Advertisements
                .Include(a => a.Sponsor)
                .FirstOrDefaultAsync(m => m.AdvertisementId == id);

            if (advertisement == null)
            {
                return NotFound();
            }

            return View(advertisement);
        }

        // GET: Advertisements/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var advertisement = await _context.Advertisements.FindAsync(id);
            if (advertisement == null)
            {
                return NotFound();
            }
            return View(advertisement);
        }

        // POST: Advertisements/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Advertisement advertisement)
        {
            if (id != advertisement.AdvertisementId)
            {
                return NotFound();
            }

            ModelState.Remove("Sponsor"); // prevent sponsor validation error

            if (ModelState.IsValid)
            {
                try
                {
                    advertisement.ModifiedDate = DateTime.UtcNow;
                    _context.Update(advertisement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Advertisements.Any(e => e.AdvertisementId == id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index), new { sponsorId = advertisement.SponsorId });
            }

            return View(advertisement);
        }

        // GET: Advertisements/Delete/{id}
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisement = await _context.Advertisements
                .Include(a => a.Sponsor)
                .FirstOrDefaultAsync(m => m.AdvertisementId == id);

            if (advertisement == null)
            {
                return NotFound();
            }

            return View(advertisement);
        }

        // POST: Advertisements/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var advertisement = await _context.Advertisements.FindAsync(id);
            if (advertisement != null)
            {
                _context.Advertisements.Remove(advertisement);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index), new { sponsorId = advertisement.SponsorId });
        }




    }
}
