using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPiosenkaNaCharcieRepository
    {
        void Add(PiosenkaNaCharcie piosenkaNaCharcie);
        void Remove(PiosenkaNaCharcie piosenkaNaCharcie);
        IEnumerable<PiosenkaNaCharcie>? GetPiosenkiByChartId(int id);
        IEnumerable<PiosenkaNaCharcie> GetAll();
    }
}
