using DAL.Interfaces;
using ListaPrzebojow.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PiosenkaNaCharcieRepository : IPiosenkaNaCharcieRepository
    {
        private readonly ListaPrzebojowContext _context;

        public PiosenkaNaCharcieRepository(ListaPrzebojowContext context)
        {
            _context = context;
        }
        public void Add(PiosenkaNaCharcie piosenkaNaCharcie)
        {
           _context.piosenkaNaCharcieDb.Add(piosenkaNaCharcie);
        }

        public IEnumerable<PiosenkaNaCharcie> GetAll()
        {
           return _context.piosenkaNaCharcieDb.ToList();
        }

        public IEnumerable<PiosenkaNaCharcie>? GetPiosenkiByChartId(int id)
        {
            return _context.piosenkaNaCharcieDb.Where(x => x.ChartPiosenekID == id).ToList();
        }

        public void Remove(PiosenkaNaCharcie piosenkaNaCharcie)
        {
            _context.piosenkaNaCharcieDb.Remove(piosenkaNaCharcie);
        }
    }
}
