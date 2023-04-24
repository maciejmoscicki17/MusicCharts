using BusinessLogicLayer;
using ListaPrzebojow.DAL;

namespace TestProjectBLL
{
    public class UnitTestBLL
    {
        [Fact]
        public void TestGetSongsByChartId2()
        {

            var chartyPiosenek = new ChartPiosenekRepositoryFake();
            chartyPiosenek.Add(new ChartPiosenek { ChartPiosenekID = 1 });
            chartyPiosenek.Add(new ChartPiosenek { ChartPiosenekID = 2 });
            var context = new ListaPrzebojowContext();
            var unitOfWork = new TestUnitOfWork(context, chartPiosenek: chartyPiosenek);
            var userService = new UserService(unitOfWork);

            Assert.Equal(25, userService.GetSongsByChartId(1).Count());

        }

        [Fact]
        public void TestGetAllChartPiosenek()
        {

            var chartyPiosenek = new ChartPiosenekRepositoryFake();
            var context = new ListaPrzebojowContext();
            var unitOfWork = new TestUnitOfWork(context, chartPiosenek: chartyPiosenek);
            var userService = new UserService(unitOfWork);

            Assert.Empty(userService.GetAllChartPiosenek());
        }

        [Fact]
        public void GetAlbumsByChartId()
        {

            var albums = new AlbumRepositoryFake();
            var context = new ListaPrzebojowContext();
            var unitOfWork = new TestUnitOfWork(context, albumRepository: albums);
            var userService = new UserService(unitOfWork);

            Assert.Empty(userService.GetAlbumsByChartId(1));
        }

        [Fact]
        public void GetSongsByChartId()
        {

            var songs = new PiosenkaRepositoryFake();
            var context = new ListaPrzebojowContext();
            var unitOfWork = new TestUnitOfWork(context, piosenkaRepository: songs);
            var userService = new UserService(unitOfWork);

            Assert.Empty(userService.GetSongsByChartId(1));
        }


    }
}