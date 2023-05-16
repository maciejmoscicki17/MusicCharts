using DAL;
using ListaPrzebojow.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUserOperations.Controllers;

namespace TestControllersMVC
{
    public class UnitTestChartPiosenekController
    {
        [Fact]
        public void TestIndexAction()
        {
            Mock<IUserService> mockUserService = new Mock<IUserService>();
            var piosenki = new List<ChartPiosenek>();
            mockUserService
                .Setup(s => s.GetAllChartPiosenek())
                .Returns(piosenki);

            ChartPiosenekController chartPiosenekController = new ChartPiosenekController(mockUserService.Object);

            var result = chartPiosenekController.Index();

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Equal(viewResult.Model, piosenki);

        }

        [Fact]
        public async Task TestSongsActionAsync()
        {
            Mock<IUserService> mockUserService = new Mock<IUserService>();
            var piosenki = new List<Piosenka>();
            mockUserService
                .Setup(s => s.GetSongsByChartId(1))
                .Returns(piosenki);

            ChartPiosenekController chartPiosenekController = new ChartPiosenekController(mockUserService.Object);

            var result = await chartPiosenekController.Songs(1);

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Equal(viewResult.Model, piosenki);

        }
    }
}
