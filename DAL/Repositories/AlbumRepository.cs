using DAL.Interfaces;
using ListaPrzebojow.DAL;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly ListaPrzebojowContext _context;

        public AlbumRepository(ListaPrzebojowContext context)
        {
            _context = context;
        }

        public void Add(Album album)
        {
            _context.albumDb.Add(album);
        }

        public IEnumerable<Album> GetAll()
        {
            return _context.albumDb.ToList();

        }

        public Album? GetById(int id)
        {
            return _context.albumDb.FirstOrDefault(a => a.AlbumID == id);
        }

        public void Remove(Album album)
        {
            _context.albumDb.Remove(album);
        }

        public async Task<IEnumerable<Album>> GetAllAsync()
        {
            return await _context.albumDb.ToListAsync();
        }

        public void Update(Album album)
        {
            _context.albumDb.Update(album);
            //return await _context.SaveChangesAsync() == 1;
            //return al != null;
        }

        public async Task<Album?> FirstOrDefaultAsync(int? id)
        {
            return await _context.albumDb.FirstOrDefaultAsync(m => m.AlbumID == id);
        }

        public async Task<Album?> FindAsync(int? id)
        {
            return await _context.albumDb.FindAsync(id);
        }

        public bool Any(int id)
        {
            return _context.albumDb.Any(e => e.AlbumID == id);
        }

    }
}
