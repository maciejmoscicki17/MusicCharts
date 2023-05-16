using DAL;
using DAL.Interfaces;
using ListaPrzebojow.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUserOperations.Controllers;

namespace TestControllersMVC
{
    public class UnitTestArtistController
    {
        [Fact]
        public async Task TestSongsActionAsync()
        {
            Mock<IUserService> user = new Mock<IUserService>();
            var piosenki = new List<Piosenka>();
            Task<IEnumerable<Piosenka>> songsAsync = new Task<IEnumerable<Piosenka>>(() => { return piosenki; });
            songsAsync.Start();
            user
                .Setup(u => u.GetSongsByArtistId(1))
                .Returns(songsAsync);

            ArtistController artistController = new ArtistController(user.Object, new UnitOfWork(new ListaPrzebojowContext()));
            
            var result = await artistController.SongsAsync(1);

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Same(viewResult.Model, piosenki);
        }
    }
}
