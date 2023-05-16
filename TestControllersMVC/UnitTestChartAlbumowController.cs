using DAL;
using ListaPrzebojow.DAL;
using Microsoft.AspNetCore.Mvc;
using WebUserOperations.Controllers;

namespace TestControllersMVC
{
    public class UnitTestChartAlbumowController
    {
        [Fact]
        public void TestIndexAction()
        {
            Mock<IUserService> mockUserService = new Mock<IUserService>();
            var chartyAlbumow = new List<ChartAlbumow>();
            mockUserService
                .Setup(s => s.GetAllChartAlbumow())
                .Returns(chartyAlbumow);

            ChartAlbumówController chartAlbumówController = new ChartAlbumówController(mockUserService.Object);

            var result = chartAlbumówController.Index();

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Equal(viewResult.Model, chartyAlbumow);
        }

        [Fact]
        public void TestAlbumsAction()
        {
            Mock<IUserService> mockUserService= new Mock<IUserService>();
            var albumy = new List<Album>();
            mockUserService
                .Setup(s => s.GetAlbumsByChartId(1))
                .Returns(albumy);
            ListaPrzebojowContext context = new ListaPrzebojowContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);

            ChartAlbumówController chartAlbumówController = new ChartAlbumówController(mockUserService.Object);

            var result = chartAlbumówController.Albums(1);

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Equal(viewResult.Model, albumy);
        }
    }
}
