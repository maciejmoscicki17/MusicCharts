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
    public class ChartController : Controller
    {
        private readonly ListaPrzebojowContext _context;

        public ChartController(ListaPrzebojowContext context)
        {
            _context = context;
        }

        // GET: Chart
        public async Task<IActionResult> Index()
        {
              return _context.chartDb != null ? 
                          View(await _context.chartDb.ToListAsync()) :
                          Problem("Entity set 'ListaPrzebojowContext.chartDb'  is null.");
        }

        // GET: Chart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.chartDb == null)
            {
                return NotFound();
            }

            var chart = await _context.chartDb
                .FirstOrDefaultAsync(m => m.ChartID == id);
            if (chart == null)
            {
                return NotFound();
            }

            return View(chart);
        }

        // GET: Chart/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChartID")] Chart chart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chart);
        }

        // GET: Chart/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.chartDb == null)
            {
                return NotFound();
            }

            var chart = await _context.chartDb.FindAsync(id);
            if (chart == null)
            {
                return NotFound();
            }
            return View(chart);
        }

        // POST: Chart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChartID")] Chart chart)
        {
            if (id != chart.ChartID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChartExists(chart.ChartID))
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
            return View(chart);
        }

        // GET: Chart/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.chartDb == null)
            {
                return NotFound();
            }

            var chart = await _context.chartDb
                .FirstOrDefaultAsync(m => m.ChartID == id);
            if (chart == null)
            {
                return NotFound();
            }

            return View(chart);
        }

        // POST: Chart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.chartDb == null)
            {
                return Problem("Entity set 'ListaPrzebojowContext.chartDb'  is null.");
            }
            var chart = await _context.chartDb.FindAsync(id);
            if (chart != null)
            {
                _context.chartDb.Remove(chart);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChartExists(int id)
        {
          return (_context.chartDb?.Any(e => e.ChartID == id)).GetValueOrDefault();
        }
    }
}
