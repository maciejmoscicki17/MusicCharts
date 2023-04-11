using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPiosenkaArtystaRepository
    {
        void Add(PiosenkaArtysta piosenkaArtysta);
        void Remove(PiosenkaArtysta piosenkaArtysta);
        PiosenkaArtysta? GetById(int id);
        IEnumerable<PiosenkaArtysta> GetAll();
    }
}
