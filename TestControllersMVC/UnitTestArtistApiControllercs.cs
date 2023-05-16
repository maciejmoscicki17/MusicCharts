using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUserOperations.Controllers;

namespace TestControllersMVC
{
   public class UnitTestArtistApiControllercs
    {
        [Fact]

        public void TestArtysci()
        {
            var artysci = new List<Piosenka>();
            artysci.Add(new Piosenka { PiosenkaID = 13, IleOdsluchan = 934573559, IleOdsluchanTydzien = 233643389, Nazwa = "Good Form", Gatunek = "Rap", AlbumID = 3 });


            Mock<IUserService> _userService = new Mock<IUserService>();
            _userService.Setup(x => x.GetSongsByArtistId(5)).Returns(Task.FromResult<IEnumerable<Piosenka>>(artysci));

            WebArtistController artysciController = new WebArtistController(_userService.Object);

            Assert.Same(artysciController.allSongsByArtistId(5).Result, artysci);

        }
    }
}
