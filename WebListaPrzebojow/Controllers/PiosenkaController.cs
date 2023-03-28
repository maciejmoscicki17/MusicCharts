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
    public class PiosenkaController : Controller
    {
        private readonly ListaPrzebojowContext _context;

        public PiosenkaController(ListaPrzebojowContext context)
        {
            _context = context;
        }

        // GET: Piosenka
        public async Task<IActionResult> Index()
        {
            var listaPrzebojowContext = _context.piosenkaDb.Include(p => p.Album).Include(p => p.Artysta);
            return View(await listaPrzebojowContext.ToListAsync());
        }

        // GET: Piosenka/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.piosenkaDb == null)
            {
                return NotFound();
            }

            var piosenka = await _context.piosenkaDb
                .Include(p => p.Album)
                .Include(p => p.Artysta)
                .FirstOrDefaultAsync(m => m.PiosenkaID == id);
            if (piosenka == null)
            {
                return NotFound();
            }

            return View(piosenka);
        }

        // GET: Piosenka/Create
        public IActionResult Create()
        {
            ViewData["PiosenkaID"] = new SelectList(_context.albumDb, "AlbumID", "Nazwa");
            ViewData["ArtystaID"] = new SelectList(_context.artystaDb, "ArtystaID", "Pseudonim");
            return View();
        }

        // POST: Piosenka/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PiosenkaID,AlbumID,ArtystaID,IleOdsluchan,Nazwa,Gatunek")] Piosenka piosenka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(piosenka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PiosenkaID"] = new SelectList(_context.albumDb, "AlbumID", "Nazwa", piosenka.PiosenkaID);
            ViewData["ArtystaID"] = new SelectList(_context.artystaDb, "ArtystaID", "Pseudonim", piosenka.ArtystaID);
            return View(piosenka);
        }

        // GET: Piosenka/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.piosenkaDb == null)
            {
                return NotFound();
            }

            var piosenka = await _context.piosenkaDb.FindAsync(id);
            if (piosenka == null)
            {
                return NotFound();
            }
            ViewData["PiosenkaID"] = new SelectList(_context.albumDb, "AlbumID", "Nazwa", piosenka.PiosenkaID);
            ViewData["ArtystaID"] = new SelectList(_context.artystaDb, "ArtystaID", "Pseudonim", piosenka.ArtystaID);
            return View(piosenka);
        }

        // POST: Piosenka/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PiosenkaID,AlbumID,ArtystaID,IleOdsluchan,Nazwa,Gatunek")] Piosenka piosenka)
        {
            if (id != piosenka.PiosenkaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(piosenka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PiosenkaExists(piosenka.PiosenkaID))
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
            ViewData["PiosenkaID"] = new SelectList(_context.albumDb, "AlbumID", "Nazwa", piosenka.PiosenkaID);
            ViewData["ArtystaID"] = new SelectList(_context.artystaDb, "ArtystaID", "Pseudonim", piosenka.ArtystaID);
            return View(piosenka);
        }

        // GET: Piosenka/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.piosenkaDb == null)
            {
                return NotFound();
            }

            var piosenka = await _context.piosenkaDb
                .Include(p => p.Album)
                .Include(p => p.Artysta)
                .FirstOrDefaultAsync(m => m.PiosenkaID == id);
            if (piosenka == null)
            {
                return NotFound();
            }

            return View(piosenka);
        }

        // POST: Piosenka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.piosenkaDb == null)
            {
                return Problem("Entity set 'ListaPrzebojowContext.piosenkaDb'  is null.");
            }
            var piosenka = await _context.piosenkaDb.FindAsync(id);
            if (piosenka != null)
            {
                _context.piosenkaDb.Remove(piosenka);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PiosenkaExists(int id)
        {
          return (_context.piosenkaDb?.Any(e => e.PiosenkaID == id)).GetValueOrDefault();
        }
    }
}
