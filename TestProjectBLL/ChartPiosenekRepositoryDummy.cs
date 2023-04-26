using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectBLL
{
    public class ChartPiosenekRepositoryDummy : IChartPiosenekRepository
    {
        public void Add(ChartPiosenek chartPiosenek)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ChartPiosenek> GetAll()
        {
            throw new NotImplementedException();
        }

        public ChartPiosenek GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(ChartPiosenek chartPiosenek)
        {
            throw new NotImplementedException();
        }
    }
}
