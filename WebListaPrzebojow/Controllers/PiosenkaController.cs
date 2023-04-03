using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using ListaPrzebojow.DAL;
using WebListaPrzebojow.Utils;

namespace WebListaPrzebojow.Controllers
{
    public class PiosenkaController : Controller
    {
        private readonly ListaPrzebojowContext _context;
        private readonly UnitOfWork unitOfWork;

        public PiosenkaController(ListaPrzebojowContext context)
        {
            _context = context;
            unitOfWork = new UnitOfWork(context);
            GlobalFunctions.Init(_context);
        }

        // GET: Piosenka
        public async Task<IActionResult> Index()
        {
              return unitOfWork.Piosenki != null ? 
                          View(await unitOfWork.Piosenki.GetAllAsync()) :
                          Problem("Entity set 'ListaPrzebojowContext.piosenkaDb'  is null.");
        }

        // GET: Piosenka/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || unitOfWork.Piosenki == null)
            {
                return NotFound();
            }

            var piosenka = await unitOfWork.Piosenki
                .FirstOrDefaultAsync(id);
            if (piosenka == null)
            {
                return NotFound();
            }

            return View(piosenka);
        }

        // GET: Piosenka/Create
        public IActionResult Create()
        {
            var albums = unitOfWork.Albums.GetAll()
                .Select(a => new SelectListItem
                {
                    Value = a.AlbumID.ToString(),
                    Text = a.Nazwa
                })
                .ToList();

            ViewBag.Albums = albums;
            return View();
        }

        // POST: Piosenka/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PiosenkaID,IleOdsluchan,Nazwa,Gatunek,AlbumID")] Piosenka piosenka)
        {
         
            if (ModelState.IsValid)
            {
                unitOfWork.Piosenki.Add(piosenka);
                await unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(piosenka);
        }

        // GET: Piosenka/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || unitOfWork.Piosenki == null)
            {
                return NotFound();
            }

            var piosenka = await unitOfWork.Piosenki.FindAsync(id);
            if (piosenka == null)
            {
                return NotFound();
            }
            var albums = unitOfWork.Albums.GetAll()
                .Select(a => new SelectListItem
                {
                    Value = a.AlbumID.ToString(),
                    Text = a.Nazwa
                })
                .ToList();

            ViewBag.Albums = albums;
            return View(piosenka);
            }

        // POST: Piosenka/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PiosenkaID,IleOdsluchan,Nazwa,Gatunek,AlbumID")] Piosenka piosenka)
        {
            if (id != piosenka.PiosenkaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.Piosenki.Update(piosenka);
                    await unitOfWork.SaveAsync();
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
            return View(piosenka);
        }

        // GET: Piosenka/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || unitOfWork.Piosenki == null)
            {
                return NotFound();
            }

            var piosenka = await unitOfWork.Piosenki
                .FirstOrDefaultAsync(id);
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
            if (unitOfWork.Piosenki == null)
            {
                return Problem("Entity set 'ListaPrzebojowContext.piosenkaDb'  is null.");
            }
            var piosenka = await unitOfWork.Piosenki.FindAsync(id);
            if (piosenka != null)
            {
                unitOfWork.Piosenki.Remove(piosenka);
            }
            
            await unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PiosenkaExists(int id)
        {
          return (unitOfWork.Piosenki?.Any(id)).GetValueOrDefault();
        }
    }
}
