using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUserOperations.Controllers;

namespace TestControllersMVC
{
    public class UnitTestChartAlbumowApiController
    {
        [Fact]

        public void TestChartAlbumow()
        {
            var albumy = new List<ChartAlbumow>();
            albumy.Add(new ChartAlbumow { ChartAlbumowID = 1, Nazwa = "top 10 miesiaca" });
            albumy.Add(new ChartAlbumow { ChartAlbumowID = 2, Nazwa = "top rap piosenki" });


            Mock<IUserService> _userService = new Mock<IUserService>();
            _userService.Setup(x => x.GetAllChartAlbumow()).Returns(albumy);

            WebChartAlbumowController chartPiosenekController = new WebChartAlbumowController(_userService.Object);

            Assert.Same(chartPiosenekController.allAlbumCharts(), albumy);

        }
    }
}
