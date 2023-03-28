using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using ListaPrzebojow.DAL;

namespace WebListaPrzebojow.Controllers
{
    public class PlaylistaController : Controller
    {
        private readonly ListaPrzebojowContext _context;

        public PlaylistaController(ListaPrzebojowContext context)
        {
            _context = context;
        }

        // GET: Playlista
        public async Task<IActionResult> Index()
        {
              return _context.playlistaDb != null ? 
                          View(await _context.playlistaDb.ToListAsync()) :
                          Problem("Entity set 'ListaPrzebojowContext.playlistaDb'  is null.");
        }

        // GET: Playlista/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.playlistaDb == null)
            {
                return NotFound();
            }

            var playlista = await _context.playlistaDb
                .FirstOrDefaultAsync(m => m.PlaylistaID == id);
            if (playlista == null)
            {
                return NotFound();
            }

            return View(playlista);
        }

        // GET: Playlista/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Playlista/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlaylistaID,Gatunek")] Playlista playlista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playlista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(playlista);
        }

        // GET: Playlista/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.playlistaDb == null)
            {
                return NotFound();
            }

            var playlista = await _context.playlistaDb.FindAsync(id);
            if (playlista == null)
            {
                return NotFound();
            }
            return View(playlista);
        }

        // POST: Playlista/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlaylistaID,Gatunek")] Playlista playlista)
        {
            if (id != playlista.PlaylistaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playlista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaylistaExists(playlista.PlaylistaID))
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
            return View(playlista);
        }

        // GET: Playlista/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.playlistaDb == null)
            {
                return NotFound();
            }

            var playlista = await _context.playlistaDb
                .FirstOrDefaultAsync(m => m.PlaylistaID == id);
            if (playlista == null)
            {
                return NotFound();
            }

            return View(playlista);
        }

        // POST: Playlista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.playlistaDb == null)
            {
                return Problem("Entity set 'ListaPrzebojowContext.playlistaDb'  is null.");
            }
            var playlista = await _context.playlistaDb.FindAsync(id);
            if (playlista != null)
            {
                _context.playlistaDb.Remove(playlista);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaylistaExists(int id)
        {
          return (_context.playlistaDb?.Any(e => e.PlaylistaID == id)).GetValueOrDefault();
        }
    }
}
