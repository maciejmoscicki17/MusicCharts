using ListaPrzebojow.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectBLL
{
    public class UnitTestUnitOfWork
    {
        [Fact]
        public void TestUnitOfWork()
        {
            var albumRepo = new AlbumRepositoryDummy();
            var piosenkaRepo = new PiosenkaRepositoryDummy();
            var chartPiosenekRepo = new ChartPiosenekRepositoryDummy();
            var context = new ListaPrzebojowContext();
            var unitOfWork = new UnitOfWork(context, albumRepository: albumRepo, chartPiosenek: chartPiosenekRepo, piosenkaRepository: piosenkaRepo);
            Assert.Same(albumRepo, unitOfWork.Albums);
            Assert.Same(piosenkaRepo, unitOfWork.Piosenki);
            Assert.Same(chartPiosenekRepo, unitOfWork.ChartyPiosenek);

        }

        [Fact]
        public void TestDummyFunction()
        {
            var albumRepo = new AlbumRepositoryDummy();
            var piosenkaRepo = new PiosenkaRepositoryDummy();
            var chartPiosenekRepo = new ChartPiosenekRepositoryDummy();
            var context = new ListaPrzebojowContext();
            var unitOfWork = new UnitOfWork(context, albumRepository: albumRepo, chartPiosenek: chartPiosenekRepo, piosenkaRepository: piosenkaRepo);
            Func<bool> func = () => albumRepo.Any(1);
            Assert.Throws<NotImplementedException>(() => func.Invoke());

        }
    }
}
