using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectBLL
{
    public class PiosenkaRepositoryDummy : IPiosenkaRepository
    {
        public void Add(Piosenka piosenka)
        {
            throw new NotImplementedException();
        }

        public bool Any(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Piosenka?> FindAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Piosenka?> FirstOrDefaultAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Piosenka> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Piosenka>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Piosenka? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Piosenka piosenka)
        {
            throw new NotImplementedException();
        }

        public void Update(Piosenka piosenka)
        {
            throw new NotImplementedException();
        }
    }
}
