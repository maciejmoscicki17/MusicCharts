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
    public class ChartPiosenekController : Controller
    {
        private readonly ListaPrzebojowContext _context;

        public ChartPiosenekController(ListaPrzebojowContext context)
        {
            _context = context;
        }

        // GET: ChartPiosenek
        public async Task<IActionResult> Index()
        {
            var listaPrzebojowContext = _context.chartPiosenekDb.Include(c => c.chart);
            return View(await listaPrzebojowContext.ToListAsync());
        }

        // GET: ChartPiosenek/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.chartPiosenekDb == null)
            {
                return NotFound();
            }

            var chartPiosenek = await _context.chartPiosenekDb
                .Include(c => c.chart)
                .FirstOrDefaultAsync(m => m.ChartPiosenekID == id);
            if (chartPiosenek == null)
            {
                return NotFound();
            }

            return View(chartPiosenek);
        }

        // GET: ChartPiosenek/Create
        public IActionResult Create()
        {
            ViewData["ChartPiosenekID"] = new SelectList(_context.chartDb, "ChartID", "ChartID");
            return View();
        }

        // POST: ChartPiosenek/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChartPiosenekID")] ChartPiosenek chartPiosenek)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chartPiosenek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChartPiosenekID"] = new SelectList(_context.chartDb, "ChartID", "ChartID", chartPiosenek.ChartPiosenekID);
            return View(chartPiosenek);
        }

        // GET: ChartPiosenek/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.chartPiosenekDb == null)
            {
                return NotFound();
            }

            var chartPiosenek = await _context.chartPiosenekDb.FindAsync(id);
            if (chartPiosenek == null)
            {
                return NotFound();
            }
            ViewData["ChartPiosenekID"] = new SelectList(_context.chartDb, "ChartID", "ChartID", chartPiosenek.ChartPiosenekID);
            return View(chartPiosenek);
        }

        // POST: ChartPiosenek/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChartPiosenekID")] ChartPiosenek chartPiosenek)
        {
            if (id != chartPiosenek.ChartPiosenekID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chartPiosenek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChartPiosenekExists(chartPiosenek.ChartPiosenekID))
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
            ViewData["ChartPiosenekID"] = new SelectList(_context.chartDb, "ChartID", "ChartID", chartPiosenek.ChartPiosenekID);
            return View(chartPiosenek);
        }

        // GET: ChartPiosenek/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.chartPiosenekDb == null)
            {
                return NotFound();
            }

            var chartPiosenek = await _context.chartPiosenekDb
                .Include(c => c.chart)
                .FirstOrDefaultAsync(m => m.ChartPiosenekID == id);
            if (chartPiosenek == null)
            {
                return NotFound();
            }

            return View(chartPiosenek);
        }

        // POST: ChartPiosenek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.chartPiosenekDb == null)
            {
                return Problem("Entity set 'ListaPrzebojowContext.chartPiosenekDb'  is null.");
            }
            var chartPiosenek = await _context.chartPiosenekDb.FindAsync(id);
            if (chartPiosenek != null)
            {
                _context.chartPiosenekDb.Remove(chartPiosenek);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChartPiosenekExists(int id)
        {
          return (_context.chartPiosenekDb?.Any(e => e.ChartPiosenekID == id)).GetValueOrDefault();
        }
    }
}
