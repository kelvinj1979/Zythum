using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesSystem.Data;
using Zythum.Areas.Beers.Models;

namespace Zythum.Areas.Beers.Controllers
{
    [Area("Beers")]
    public class TBeersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TBeersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Beers/TBeers
        public async Task<IActionResult> Index()
        {
              return View(await _context.TBeers.ToListAsync());
        }

        // GET: Beers/TBeers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TBeers == null)
            {
                return NotFound();
            }

            var tBeers = await _context.TBeers
                .FirstOrDefaultAsync(m => m.BeerId == id);
            if (tBeers == null)
            {
                return NotFound();
            }

            return View(tBeers);
        }

        // GET: Beers/TBeers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Beers/TBeers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BeerId,BeerName,BeerStyle,BeerABV,BeerIBU,BeerDescription,Image,BreweryId")] TBeers tBeers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tBeers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tBeers);
        }

        // GET: Beers/TBeers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TBeers == null)
            {
                return NotFound();
            }

            var tBeers = await _context.TBeers.FindAsync(id);
            if (tBeers == null)
            {
                return NotFound();
            }
            return View(tBeers);
        }

        // POST: Beers/TBeers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BeerId,BeerName,BeerStyle,BeerABV,BeerIBU,BeerDescription,Image,BreweryId")] TBeers tBeers)
        {
            if (id != tBeers.BeerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tBeers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TBeersExists(tBeers.BeerId))
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
            return View(tBeers);
        }

        // GET: Beers/TBeers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TBeers == null)
            {
                return NotFound();
            }

            var tBeers = await _context.TBeers
                .FirstOrDefaultAsync(m => m.BeerId == id);
            if (tBeers == null)
            {
                return NotFound();
            }

            return View(tBeers);
        }

        // POST: Beers/TBeers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TBeers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TBeers'  is null.");
            }
            var tBeers = await _context.TBeers.FindAsync(id);
            if (tBeers != null)
            {
                _context.TBeers.Remove(tBeers);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TBeersExists(int id)
        {
          return _context.TBeers.Any(e => e.BeerId == id);
        }
    }
}
