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
    public class VolunteerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VolunteerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Volunteer
        [Authorize(Roles = "  Admin, Church member")]
        public async Task<IActionResult> Index()
        {
              return _context.Volunteer != null ? 
                          View(await _context.Volunteer.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Volunteer'  is null.");
        }

        // GET: Volunteer/Details/5
        [Authorize(Roles = "  Admin, Church member")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Volunteer == null)
            {
                return NotFound();
            }

            var volunteer = await _context.Volunteer
                .FirstOrDefaultAsync(m => m.VolunteerId == id);
            if (volunteer == null)
            {
                return NotFound();
            }

            return View(volunteer);
        }

        // GET: Volunteer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Volunteer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VolunteerId,VolunteerName,VolunteerSurname,TaskDescription")] Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(volunteer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(volunteer);
        }

        // GET: Volunteer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Volunteer == null)
            {
                return NotFound();
            }

            var volunteer = await _context.Volunteer.FindAsync(id);
            if (volunteer == null)
            {
                return NotFound();
            }
            return View(volunteer);
        }

        // POST: Volunteer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VolunteerId,VolunteerName,VolunteerSurname,TaskDescription")] Volunteer volunteer)
        {
            if (id != volunteer.VolunteerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(volunteer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VolunteerExists(volunteer.VolunteerId))
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
            return View(volunteer);
        }

        // GET: Volunteer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Volunteer == null)
            {
                return NotFound();
            }

            var volunteer = await _context.Volunteer
                .FirstOrDefaultAsync(m => m.VolunteerId == id);
            if (volunteer == null)
            {
                return NotFound();
            }

            return View(volunteer);
        }

        // POST: Volunteer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Volunteer == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Volunteer'  is null.");
            }
            var volunteer = await _context.Volunteer.FindAsync(id);
            if (volunteer != null)
            {
                _context.Volunteer.Remove(volunteer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VolunteerExists(int id)
        {
          return (_context.Volunteer?.Any(e => e.VolunteerId == id)).GetValueOrDefault();
        }
    }
}
