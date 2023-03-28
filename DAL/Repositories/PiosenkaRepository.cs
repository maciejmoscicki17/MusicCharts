using DAL.Interfaces;
using ListaPrzebojow.DAL;

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
    }
}
