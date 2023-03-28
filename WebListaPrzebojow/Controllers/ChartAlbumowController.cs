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
    public class ChartAlbumowController : Controller
    {
        private readonly ListaPrzebojowContext _context;

        public ChartAlbumowController(ListaPrzebojowContext context)
        {
            _context = context;
        }

        // GET: ChartAlbumow
        public async Task<IActionResult> Index()
        {
            var listaPrzebojowContext = _context.chartAlbumowDb.Include(c => c.chart);
            return View(await listaPrzebojowContext.ToListAsync());
        }

        // GET: ChartAlbumow/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.chartAlbumowDb == null)
            {
                return NotFound();
            }

            var chartAlbumow = await _context.chartAlbumowDb
                .Include(c => c.chart)
                .FirstOrDefaultAsync(m => m.ChartAlbumowID == id);
            if (chartAlbumow == null)
            {
                return NotFound();
            }

            return View(chartAlbumow);
        }

        // GET: ChartAlbumow/Create
        public IActionResult Create()
        {
            ViewData["ChartAlbumowID"] = new SelectList(_context.chartDb, "ChartID", "ChartID");
            return View();
        }

        // POST: ChartAlbumow/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChartAlbumowID,ChartID")] ChartAlbumow chartAlbumow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chartAlbumow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChartAlbumowID"] = new SelectList(_context.chartDb, "ChartID", "ChartID", chartAlbumow.ChartAlbumowID);
            return View(chartAlbumow);
        }

        // GET: ChartAlbumow/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.chartAlbumowDb == null)
            {
                return NotFound();
            }

            var chartAlbumow = await _context.chartAlbumowDb.FindAsync(id);
            if (chartAlbumow == null)
            {
                return NotFound();
            }
            ViewData["ChartAlbumowID"] = new SelectList(_context.chartDb, "ChartID", "ChartID", chartAlbumow.ChartAlbumowID);
            return View(chartAlbumow);
        }

        // POST: ChartAlbumow/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChartAlbumowID,ChartID")] ChartAlbumow chartAlbumow)
        {
            if (id != chartAlbumow.ChartAlbumowID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chartAlbumow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChartAlbumowExists(chartAlbumow.ChartAlbumowID))
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
            ViewData["ChartAlbumowID"] = new SelectList(_context.chartDb, "ChartID", "ChartID", chartAlbumow.ChartAlbumowID);
            return View(chartAlbumow);
        }

        // GET: ChartAlbumow/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.chartAlbumowDb == null)
            {
                return NotFound();
            }

            var chartAlbumow = await _context.chartAlbumowDb
                .Include(c => c.chart)
                .FirstOrDefaultAsync(m => m.ChartAlbumowID == id);
            if (chartAlbumow == null)
            {
                return NotFound();
            }

            return View(chartAlbumow);
        }

        // POST: ChartAlbumow/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.chartAlbumowDb == null)
            {
                return Problem("Entity set 'ListaPrzebojowContext.chartAlbumowDb'  is null.");
            }
            var chartAlbumow = await _context.chartAlbumowDb.FindAsync(id);
            if (chartAlbumow != null)
            {
                _context.chartAlbumowDb.Remove(chartAlbumow);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChartAlbumowExists(int id)
        {
          return (_context.chartAlbumowDb?.Any(e => e.ChartAlbumowID == id)).GetValueOrDefault();
        }
    }
}
