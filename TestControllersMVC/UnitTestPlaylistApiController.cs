using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUserOperations.Controllers;

namespace TestControllersMVC
{
     public class UnitTestPlaylistApiController
    {
        [Fact]

        public void TestLiczbaPlayList()
        {
            var playlisty = new List<Playlista>();
            playlisty.Add(new Playlista { PlaylistaID = 1, Nazwa = "Vibe", Gatunek = "Rap" });
            playlisty.Add(new Playlista { PlaylistaID = 2, Nazwa = "Relax", Gatunek = "Rap" });
            playlisty.Add(new Playlista { PlaylistaID = 3, Nazwa = "Sunday", Gatunek = "Rap" });
            playlisty.Add(new Playlista { PlaylistaID = 4, Nazwa = "Girls Night", Gatunek = "Pop" });

            Mock<IUserService> _userService = new Mock<IUserService>();
            _userService.Setup(x => x.GetAllPlaylist()).Returns(Task.FromResult<IEnumerable<Playlista>>(playlisty));

            WebPlaylistaController playlistaController = new WebPlaylistaController(_userService.Object);

            Assert.Same(playlistaController.allPlaylists().Result, playlisty);

        }

        

    }
}
