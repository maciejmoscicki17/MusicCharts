using DAL.Interfaces;
using ListaPrzebojow.DAL;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ArtystaRepository : IArtystaRepository
    {
        private readonly ListaPrzebojowContext _context;

        public ArtystaRepository(ListaPrzebojowContext context)
        {
            _context = context;
        }

        public void Add(Artysta artysta)
        {
            _context.artystaDb.Add(artysta);
        }

        public IEnumerable<Artysta> GetAll()
        {
            return _context.artystaDb.ToList();

        }

        public Artysta GetById(int id)
        {
            return _context.artystaDb.FirstOrDefault(a => a.ArtystaID == id);
        }

        public void Remove(Artysta artysta)
        {
            _context.artystaDb.Remove(artysta);
        }

        public async Task<IEnumerable<Artysta>> GetAllAsync()
        {
            return await _context.artystaDb.ToListAsync();
        }

        public void Update(Artysta artysta)
        {
            _context.artystaDb.Update(artysta);
        }

        public async Task<Artysta?> FirstOrDefaultAsync(int? id)
        {
            return await _context.artystaDb.FirstOrDefaultAsync(m => m.ArtystaID == id);
        }

        public async Task<Artysta?> FindAsync(int? id)
        {
            return await _context.artystaDb.FindAsync(id);
        }

        public bool Any(int id)
        {
            return _context.artystaDb.Any(e => e.ArtystaID == id);
        }
    }
}
