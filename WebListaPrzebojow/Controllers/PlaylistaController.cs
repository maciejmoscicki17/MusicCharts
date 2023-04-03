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
        private readonly UnitOfWork unitOfWork;

        public PlaylistaController(ListaPrzebojowContext context)
        {
            _context = context;
            unitOfWork = new UnitOfWork(context);
        }

        // GET: Playlista
        public async Task<IActionResult> Index()
        {
              return unitOfWork.Playlisty != null ? 
                          View(await unitOfWork.Playlisty.GetAllAsync()) :
                          Problem("Entity set 'ListaPrzebojowContext.playlistaDb'  is null.");
        }

        // GET: Playlista/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || unitOfWork.Playlisty == null)
            {
                return NotFound();
            }

            var playlista = await unitOfWork.Playlisty
                .FirstOrDefaultAsync(id);
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
        public async Task<IActionResult> Create([Bind("PlaylistaID,Gatunek,Nazwa")] Playlista playlista)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Playlisty.Add(playlista);
                await unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(playlista);
        }

        // GET: Playlista/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || unitOfWork.Playlisty == null)
            {
                return NotFound();
            }

            var playlista = await unitOfWork.Playlisty.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("PlaylistaID,Gatunek,Nazwa")] Playlista playlista)
        {
            if (id != playlista.PlaylistaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.Playlisty.Update(playlista);
                    await unitOfWork.SaveAsync();
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
            if (id == null || unitOfWork.Playlisty == null)
            {
                return NotFound();
            }

            var playlista = await unitOfWork.Playlisty
                .FirstOrDefaultAsync(id);
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
            if (unitOfWork.Playlisty == null)
            {
                return Problem("Entity set 'ListaPrzebojowContext.playlistaDb'  is null.");
            }
            var playlista = await unitOfWork.Playlisty.FindAsync(id);
            if (playlista != null)
            {
                unitOfWork.Playlisty.Remove(playlista);
            }
            
            await unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaylistaExists(int id)
        {
          return (unitOfWork.Playlisty?.Any(id)).GetValueOrDefault();
        }
    }
}
