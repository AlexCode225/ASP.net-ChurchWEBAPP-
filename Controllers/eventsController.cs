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
    public class eventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public eventsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [Authorize(Roles = "  Admin, Church member")]
        // GET: events
        public async Task<IActionResult> Index()
        {
              return _context.Events != null ? 
                          View(await _context.Events.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Events'  is null.");
        }


        [Authorize(Roles = "  Admin, Church member")]
        // everyone can access the  events/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var events = await _context.Events
                .FirstOrDefaultAsync(m => m.eventID == id);
            if (events == null)
            {
                return NotFound();
            }

            return View(events);
        }


        [Authorize(Roles = "Admin")]
        // only admin can post events/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("eventID,eventName,Description,eventTime")] events events)
        {
            if (ModelState.IsValid)
            {
                _context.Add(events);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(events);
        }

        [Authorize(Roles = "Admin")]
        // GET: events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var events = await _context.Events.FindAsync(id);
            if (events == null)
            {
                return NotFound();
            }
            return View(events);
        }

        // POST: events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("eventID,eventName,Description,eventTime")] events events)
        {
            if (id != events.eventID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(events);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!eventsExists(events.eventID))
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
            return View(events);
        }


  // only admin can delete: events/Delete/
         [Authorize(Roles = "Admin")]  
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var events = await _context.Events
                .FirstOrDefaultAsync(m => m.eventID == id);
            if (events == null)
            {
                return NotFound();
            }

            return View(events);
        }
        [Authorize(Roles = "Admin")]
        // POST: events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Events == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Events'  is null.");
            }
            var events = await _context.Events.FindAsync(id);
            if (events != null)
            {
                _context.Events.Remove(events);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool eventsExists(int id)
        {
          return (_context.Events?.Any(e => e.eventID == id)).GetValueOrDefault();
        }
    }
}
