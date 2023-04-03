using DAL.Interfaces;
using ListaPrzebojow.DAL;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class PlaylistaRepository : IPlaylistaRepository
    {
        private readonly ListaPrzebojowContext _context;

        public PlaylistaRepository(ListaPrzebojowContext context)
        {
            _context = context;
        }

        public void Add(Playlista playlista)
        {
            _context.playlistaDb.Add(playlista);
        }

        public IEnumerable<Playlista> GetAll()
        {
            return _context.playlistaDb.ToList();

        }

        public Playlista GetById(int id)
        {
            return _context.playlistaDb.FirstOrDefault(a => a.PlaylistaID == id);
        }

        public void Remove(Playlista playlista)
        {
            _context.playlistaDb.Remove(playlista);
        }

        public async Task<IEnumerable<Playlista>> GetAllAsync()
        {
            return await _context.playlistaDb.ToListAsync();
        }

        public void Update(Playlista playlista)
        {
            _context.playlistaDb.Update(playlista);
        }

        public async Task<Playlista?> FirstOrDefaultAsync(int? id)
        {
            return await _context.playlistaDb.FirstOrDefaultAsync(m => m.PlaylistaID == id);
        }

        public async Task<Playlista?> FindAsync(int? id)
        {
            return await _context.playlistaDb.FindAsync(id);
        }

        public bool Any(int id)
        {
            return _context.playlistaDb.Any(e => e.PlaylistaID == id);
        }
    }
}
