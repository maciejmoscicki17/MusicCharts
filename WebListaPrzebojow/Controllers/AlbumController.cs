using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using ListaPrzebojow.DAL;

namespace WebListaPrzebojow.Controllers
{
    public class AlbumController : Controller
    {
        private readonly ListaPrzebojowContext _context;
        private readonly UnitOfWork unitOfWork;

        public AlbumController(ListaPrzebojowContext context)
        {
            _context = context;
            unitOfWork = new UnitOfWork(_context);
        }

        // GET: Album
        public async Task<IActionResult> Index()
        {
            //var albums = await unitOfWork.Albums.GetAllAsync();
            return unitOfWork.Albums != null ? 
                View(await unitOfWork.Albums.GetAllAsync()) : 
                Problem("Entity set 'ListaPrzebojowContext.albumDb'  is null.");
        }

        // GET: Album/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || unitOfWork.Albums == null)
            {
                return NotFound();
            }
            var test = unitOfWork.Albums == null;

            var album = await unitOfWork.Albums
                .FirstOrDefaultAsync(id);

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
                unitOfWork.Albums.Add(album);
                await unitOfWork.SaveAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(album);
        }

        // GET: Album/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || unitOfWork.Albums == null)
            {
                return NotFound();
            }

            var album = await unitOfWork.Albums.FindAsync(id);
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
                    unitOfWork.Albums.Update(album);
                    await unitOfWork.SaveAsync();
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
            if (id == null || unitOfWork.Albums == null)
            {
                return NotFound();
            }

            var album = await unitOfWork.Albums
                .FirstOrDefaultAsync(id);
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
            if (unitOfWork.Albums == null)
            {
                return Problem("Entity set 'ListaPrzebojowContext.albumDb'  is null.");
            }
            var album = await unitOfWork.Albums.FindAsync(id);
            if (album != null)
            {
                unitOfWork.Albums.Remove(album);
            }
            
            await unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumExists(int id)
        {
          return (unitOfWork.Albums?.Any(id)).GetValueOrDefault();
        }
    }
}
