using DAL;
using ListaPrzebojow.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectBLL;
using WebUserOperations.Controllers;

namespace TestControllersMVC
{
    public class UnitTestPlaylistController
    {
        [Fact]
        public async Task TestIndexActionAsync()
        {
            Mock<IUserService> mockUserService = new Mock<IUserService>();
            var playlists = new List<Playlista>();
            Task<IEnumerable<Playlista>> playlistsAsync = new Task<IEnumerable<Playlista>>(() => { return playlists; });
            playlistsAsync.Start(); 
            mockUserService
                .Setup(s => s.GetAllPlaylist())
                .Returns(playlistsAsync);

            PlaylistController playlistController = new PlaylistController(mockUserService.Object);

            var result = await playlistController.Index();

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Equal(viewResult.Model, playlists);
        }

        [Fact]
        public async Task TestSongsActionAsync()
        {
            PiosenkaRepositoryFake piosenkaRepositoryFake = new PiosenkaRepositoryFake();
            UnitOfWork unitOfWork = new UnitOfWork(new ListaPrzebojowContext(), piosenkaRepository: piosenkaRepositoryFake);
            UserService userService = new UserService(unitOfWork);
            var songs = await userService.GetSongsByPlaylistId(1);

            PlaylistController playlistController = new PlaylistController(userService);

            var result = await playlistController.SongsAsync(1);

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Equal(viewResult.Model, songs);
        }
    }
}
