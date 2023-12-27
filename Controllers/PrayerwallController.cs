using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stock_system.Data;
using Stock_system.Models;

namespace Stock_system.Controllers
{
    public class PrayerwallController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrayerwallController(ApplicationDbContext context)
        {
            _context = context;
        }


        [Authorize(Roles = "  Admin, Church member")]
        // GET: Prayerwall
        public async Task<IActionResult> Index()
        {
              return _context.Prayerwalls != null ? 
                          View(await _context.Prayerwalls.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Prayerwalls'  is null.");
        }

        [Authorize(Roles = "  Admin, Church member")]
        // GET: Prayerwall/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prayerwalls == null)
            {
                return NotFound();
            }

            var prayerwall = await _context.Prayerwalls
                .FirstOrDefaultAsync(m => m.PrayerId == id);
            if (prayerwall == null)
            {
                return NotFound();
            }

            return View(prayerwall);
        }
        [Authorize(Roles = "  Admin, Church member")]
        // GET: Prayerwall/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prayerwall/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrayerId,Name,PrayerTopic,PrayerDetails,ScriptureRefs,DayRequested")] Prayerwall prayerwall)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prayerwall);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prayerwall);
        }
        [Authorize(Roles = "  Admin, Church member")]
        // GET: Prayerwall/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Prayerwalls == null)
            {
                return NotFound();
            }

            var prayerwall = await _context.Prayerwalls.FindAsync(id);
            if (prayerwall == null)
            {
                return NotFound();
            }
            return View(prayerwall);
        }

        // POST: Prayerwall/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrayerId,Name,PrayerTopic,PrayerDetails,ScriptureRefs,DayRequested")] Prayerwall prayerwall)
        {
            if (id != prayerwall.PrayerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prayerwall);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrayerwallExists(prayerwall.PrayerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(prayerwall);
        }
        [Authorize(Roles = "  Admin, Church member")]
        // GET: Prayerwall/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prayerwalls == null)
            {
                return NotFound();
            }

            var prayerwall = await _context.Prayerwalls
                .FirstOrDefaultAsync(m => m.PrayerId == id);
            if (prayerwall == null)
            {
                return NotFound();
            }

            return View(prayerwall);
        }

        // POST: Prayerwall/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prayerwalls == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Prayerwalls'  is null.");
            }
            var prayerwall = await _context.Prayerwalls.FindAsync(id);
            if (prayerwall != null)
            {
                _context.Prayerwalls.Remove(prayerwall);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrayerwallExists(int id)
        {
          return (_context.Prayerwalls?.Any(e => e.PrayerId == id)).GetValueOrDefault();
        }
    }
}
