using DAL.Interfaces;
using ListaPrzebojow.DAL;

namespace DAL.Repositories
{
    public class PiosenkaArtystaRepository : IPiosenkaArtystaRepository
    {
        private readonly ListaPrzebojowContext _context;

        public PiosenkaArtystaRepository(ListaPrzebojowContext context)
        {
            _context = context;
        }
        public void Add(PiosenkaArtysta piosenkaArtysta)
        {
            _context.piosenkaArtystaDb.Add(piosenkaArtysta);
        }

        public IEnumerable<PiosenkaArtysta> GetAll()
        {
            return _context.piosenkaArtystaDb.ToList();
        }

        public PiosenkaArtysta? GetById(int id)
        {
            return _context.piosenkaArtystaDb.Find(id);
        }

        public void Remove(PiosenkaArtysta piosenkaArtysta)
        {
            _context.piosenkaArtystaDb.Remove(piosenkaArtysta);
        }
    }
}
