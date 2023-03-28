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
    public class ArtystaController : Controller
    {
        private readonly ListaPrzebojowContext _context;

        public ArtystaController(ListaPrzebojowContext context)
        {
            _context = context;
        }

        // GET: Artysta
        public async Task<IActionResult> Index()
        {
              return _context.artystaDb != null ? 
                          View(await _context.artystaDb.ToListAsync()) :
                          Problem("Entity set 'ListaPrzebojowContext.artystaDb'  is null.");
        }

        // GET: Artysta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.artystaDb == null)
            {
                return NotFound();
            }

            var artysta = await _context.artystaDb
                .FirstOrDefaultAsync(m => m.ArtystaID == id);
            if (artysta == null)
            {
                return NotFound();
            }

            return View(artysta);
        }

        // GET: Artysta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artysta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtystaID,SluchaczeWMiesiacu,Pseudonim")] Artysta artysta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artysta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artysta);
        }

        // GET: Artysta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.artystaDb == null)
            {
                return NotFound();
            }

            var artysta = await _context.artystaDb.FindAsync(id);
            if (artysta == null)
            {
                return NotFound();
            }
            return View(artysta);
        }

        // POST: Artysta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArtystaID,SluchaczeWMiesiacu,Pseudonim")] Artysta artysta)
        {
            if (id != artysta.ArtystaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artysta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtystaExists(artysta.ArtystaID))
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
            return View(artysta);
        }

        // GET: Artysta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.artystaDb == null)
            {
                return NotFound();
            }

            var artysta = await _context.artystaDb
                .FirstOrDefaultAsync(m => m.ArtystaID == id);
            if (artysta == null)
            {
                return NotFound();
            }

            return View(artysta);
        }

        // POST: Artysta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.artystaDb == null)
            {
                return Problem("Entity set 'ListaPrzebojowContext.artystaDb'  is null.");
            }
            var artysta = await _context.artystaDb.FindAsync(id);
            if (artysta != null)
            {
                _context.artystaDb.Remove(artysta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtystaExists(int id)
        {
          return (_context.artystaDb?.Any(e => e.ArtystaID == id)).GetValueOrDefault();
        }
    }
}
