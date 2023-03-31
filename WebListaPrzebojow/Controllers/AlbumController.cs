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
    public class AlbumController : Controller
    {
        private readonly ListaPrzebojowContext _context;

        public AlbumController(ListaPrzebojowContext context)
        {
            _context = context;
        }

        // GET: Album
        public async Task<IActionResult> Index()
        {
              return _context.albumDb != null ? 
                          View(await _context.albumDb.ToListAsync()) :
                          Problem("Entity set 'ListaPrzebojowContext.albumDb'  is null.");
        }

        // GET: Album/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.albumDb == null)
            {
                return NotFound();
            }

            var album = await _context.albumDb
                .FirstOrDefaultAsync(m => m.AlbumID == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // GET: Album/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Album/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlbumID,Nazwa")] Album album)
        {
            if (ModelState.IsValid)
            {
                _context.Add(album);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(album);
        }

        // GET: Album/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.albumDb == null)
            {
                return NotFound();
            }

            var album = await _context.albumDb.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }
            return View(album);
        }

        // POST: Album/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlbumID,Nazwa")] Album album)
        {
            if (id != album.AlbumID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(album);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(album.AlbumID))
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
            return View(album);
        }

        // GET: Album/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.albumDb == null)
            {
                return NotFound();
            }

            var album = await _context.albumDb
                .FirstOrDefaultAsync(m => m.AlbumID == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // POST: Album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.albumDb == null)
            {
                return Problem("Entity set 'ListaPrzebojowContext.albumDb'  is null.");
            }
            var album = await _context.albumDb.FindAsync(id);
            if (album != null)
            {
                _context.albumDb.Remove(album);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumExists(int id)
        {
          return (_context.albumDb?.Any(e => e.AlbumID == id)).GetValueOrDefault();
        }
    }
}
