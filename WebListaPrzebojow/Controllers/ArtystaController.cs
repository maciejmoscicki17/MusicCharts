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
        private readonly UnitOfWork unitOfWork;

        public ArtystaController(ListaPrzebojowContext context)
        {
            _context = context;
            unitOfWork = new UnitOfWork(_context);
        }

        // GET: Artysta
        public async Task<IActionResult> Index()
        {
              return unitOfWork.Artyści != null ? 
                          View(await unitOfWork.Artyści.GetAllAsync()) :
                          Problem("Entity set 'ListaPrzebojowContext.artystaDb'  is null.");
        }

        // GET: Artysta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || unitOfWork.Artyści == null)
            {
                return NotFound();
            }

            var artysta = await unitOfWork.Artyści
                .FirstOrDefaultAsync(id);
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
                unitOfWork.Artyści.Add(artysta);
                await unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artysta);
        }

        // GET: Artysta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || unitOfWork.Artyści == null)
            {
                return NotFound();
            }

            var artysta = await unitOfWork.Artyści.FindAsync(id);
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
                    unitOfWork.Artyści.Update(artysta);
                    await unitOfWork.SaveAsync();
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
            if (id == null || unitOfWork.Artyści == null)
            {
                return NotFound();
            }

            var artysta = await unitOfWork.Artyści
                .FirstOrDefaultAsync(id);
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
            if (unitOfWork.Artyści == null)
            {
                return Problem("Entity set 'ListaPrzebojowContext.artystaDb'  is null.");
            }
            var artysta = await unitOfWork.Artyści.FindAsync(id);
            if (artysta != null)
            {
                unitOfWork.Artyści.Remove(artysta);
            }
            
            await unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtystaExists(int id)
        {
          return (unitOfWork.Artyści?.Any(id)).GetValueOrDefault();
        }
    }
}
