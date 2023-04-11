using DAL.Interfaces;
using ListaPrzebojow.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PlaylistaPiosenkaRepository : IPlaylistaPiosenkaRepository
    {
        private readonly ListaPrzebojowContext _context;

        public PlaylistaPiosenkaRepository(ListaPrzebojowContext context)
        {
            _context = context;
        }
        public void Add(PiosenkaNaPlayliscie playlistaPiosenka)
        {
            _context.piosenkaNaPlayliscieDb.Add(playlistaPiosenka);
        }

        public IEnumerable<PiosenkaNaPlayliscie> GetAll()
        {
            return _context.piosenkaNaPlayliscieDb.ToList();
        }

        public IEnumerable<PiosenkaNaPlayliscie>? GetAllByPlaylistaId(int id)
        {
            return _context.piosenkaNaPlayliscieDb.Where(x => x.PlaylistaID == id).ToList();
        }

        public void Remove(PiosenkaNaPlayliscie playlistaPiosenka)
        {
            _context.piosenkaNaPlayliscieDb.Remove(playlistaPiosenka);
        }
    }
}
