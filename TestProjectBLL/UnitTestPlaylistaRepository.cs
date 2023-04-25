using DAL.Repositories;
using ListaPrzebojow.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectBLL
{
    public class UnitTestPlaylistaRepository
    {
        [Fact]
        public void TestAddPlaylista()
        {
            var options = new DbContextOptionsBuilder<ListaPrzebojowContext>()
                        .UseInMemoryDatabase("Testowa")
                        .Options;
            var listaPrzebojowContext = new ListaPrzebojowContext(options);
            PlaylistaRepository playlistaRepository = new PlaylistaRepository(listaPrzebojowContext);

            Assert.Empty(playlistaRepository.GetAll());
            playlistaRepository.Add(new Playlista { PlaylistaID = 1, Nazwa = "Vibe", Gatunek = "Rap" });
            listaPrzebojowContext.SaveChanges();
            Assert.Equal(1, playlistaRepository.GetAll().Count());
        }
    }
}
