using Microsoft.AspNetCore.Mvc;
using UpSkillDashboard.Models;
using System.Linq;
using System;
using UpSkillDashboard.Data;

namespace UpSkillDashboard.Controllers
{
    public class SponsorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SponsorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1️⃣ Show all sponsors with filters
        public IActionResult Index(string searchName, bool? isActive, DateTime? startDate, DateTime? endDate)
        {
            var sponsors = _context.Sponsors.AsQueryable();

            if (!string.IsNullOrEmpty(searchName))
            {
                sponsors = sponsors.Where(s => s.Name.Contains(searchName));
            }

            if (isActive.HasValue)
            {
                sponsors = sponsors.Where(s => s.IsActive == isActive.Value);
            }

            if (startDate.HasValue)
            {
                sponsors = sponsors.Where(s => s.StartDate >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                sponsors = sponsors.Where(s => s.EndDate <= endDate.Value);
            }

            return View(sponsors.ToList());
        }

        // 2️⃣ Create a new sponsor (GET)
        public IActionResult Create()
        {
            return View();
        }

        // 3️⃣ Create a new sponsor (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Sponsor sponsor)
        {
            if (ModelState.IsValid)
            {
                sponsor.IsActive = true;
                sponsor.CreatedDate = DateTime.UtcNow;
                _context.Sponsors.Add(sponsor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sponsor);
        }

        // 4️⃣ Edit sponsor details (GET)
        public IActionResult Edit(int id)
        {
            var sponsor = _context.Sponsors.Find(id);
            if (sponsor == null) return NotFound();
            return View(sponsor);
        }

        // 5️⃣ Edit sponsor details (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Sponsor sponsor)
        {
            if (ModelState.IsValid)
            {
                var existingSponsor = _context.Sponsors.Find(sponsor.SponsorId);
                if (existingSponsor == null) return NotFound();

                sponsor.StartDate = existingSponsor.StartDate;
                _context.Entry(existingSponsor).CurrentValues.SetValues(sponsor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sponsor);
        }

        // 6️⃣ Manually deactivate/reactivate a sponsor
        public IActionResult ToggleStatus(int id)
        {
            var sponsor = _context.Sponsors.Find(id);
            if (sponsor == null) return NotFound();

            sponsor.IsActive = !sponsor.IsActive;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // 7️⃣ Renew sponsor (GET)
        public IActionResult Renew(int id)
        {
            var sponsor = _context.Sponsors.Find(id);
            if (sponsor == null) return NotFound();
            return View(sponsor);
        }

        // 8️⃣ Renew sponsor (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Renew(int SponsorId, DateTime EndDate)
        {
            var sponsor = _context.Sponsors.Find(SponsorId);
            if (sponsor == null) return NotFound();

            sponsor.StartDate = DateTime.UtcNow;
            sponsor.EndDate = EndDate;
            sponsor.IsActive = true;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // 9️⃣ Delete sponsor (GET - Confirm Page)
        public IActionResult Delete(int id)
        {
            var sponsor = _context.Sponsors.Find(id);
            if (sponsor == null) return NotFound();
            return View(sponsor);
        }

        // 🔟 Delete sponsor (POST - Confirm Deletion)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var sponsor = _context.Sponsors.Find(id);
            if (sponsor == null) return NotFound();

            _context.Sponsors.Remove(sponsor);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}