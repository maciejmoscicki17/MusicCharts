using DAL.Interfaces;
using ListaPrzebojow.DAL;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class PiosenkaRepository : IPiosenkaRepository
    {
        private readonly ListaPrzebojowContext _context;

        public PiosenkaRepository(ListaPrzebojowContext context)
        {
            _context = context;
        }

        public void Add(Piosenka piosenka)
        {
            _context.piosenkaDb.Add(piosenka);
        }

        public IEnumerable<Piosenka> GetAll()
        {
            return _context.piosenkaDb.ToList();

        }

        public Piosenka GetById(int id)
        {
            return _context.piosenkaDb.FirstOrDefault(a => a.PiosenkaID == id);
        }

        public void Remove(Piosenka piosenka)
        {
            _context.piosenkaDb.Remove(piosenka);
        }

        public async Task<IEnumerable<Piosenka>> GetAllAsync()
        {
            return await _context.piosenkaDb.ToListAsync();
        }

        public void Update(Piosenka piosenka)
        {
            _context.piosenkaDb.Update(piosenka);
        }

        public async Task<Piosenka?> FirstOrDefaultAsync(int? id)
        {
            return await _context.piosenkaDb.FirstOrDefaultAsync(m => m.PiosenkaID == id);
        }

        public async Task<Piosenka?> FindAsync(int? id)
        {
            return await _context.piosenkaDb.FindAsync(id);
        }

        public bool Any(int id)
        {
            return _context.piosenkaDb.Any(e => e.PiosenkaID == id);
        }
    }
}
