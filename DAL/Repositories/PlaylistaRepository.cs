using DAL.Interfaces;
using ListaPrzebojow.DAL;

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
    }
}
