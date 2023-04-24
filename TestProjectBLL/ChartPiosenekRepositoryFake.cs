using DAL;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectBLL
{
    internal class ChartPiosenekRepositoryFake : IChartPiosenekRepository
    {
        private List<ChartPiosenek> charts = new List<ChartPiosenek>();
        public void Add(ChartPiosenek chartPiosenek)
        {
            charts.Add(chartPiosenek);
        }

        public IEnumerable<ChartPiosenek> GetAll()
        {
            return charts;
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
