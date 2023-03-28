using DAL.Interfaces;
using ListaPrzebojow.DAL;

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
    }
}
