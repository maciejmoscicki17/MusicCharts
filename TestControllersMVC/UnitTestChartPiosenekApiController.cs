using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUserOperations.Controllers;

namespace TestControllersMVC
{
    public class UnitTestChartPiosenekApiController
    {
        [Fact]

        public void TestChartowPiosenek()
        {
            var charty = new List<ChartPiosenek>();
            charty.Add(new ChartPiosenek { ChartPiosenekID = 1, Nazwa = "top 10 miesiaca" });
            charty.Add(new ChartPiosenek { ChartPiosenekID = 2, Nazwa = "top 10 pop" });

            Mock<IUserService> _userService = new Mock<IUserService>();
            _userService.Setup(x => x.GetAllChartPiosenek()).Returns(charty);

            WebChartPiosenekController chartPiosenekController = new WebChartPiosenekController(_userService.Object);

            Assert.Same(chartPiosenekController.allSongsCharts(), charty);

        }
    }
}
