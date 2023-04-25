using DAL.Repositories;
using ListaPrzebojow.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectBLL
{
    public class UnitTestArtystaRepository
    {
        [Fact]
        public void TestGetArtysci()
        {
            var options = new DbContextOptionsBuilder<ListaPrzebojowContext>()
                    .UseInMemoryDatabase("Testowa")
                .Options;
            var listaPrzebojowContext = new ListaPrzebojowContext(options);
            ArtystaRepository artystaRepository = new ArtystaRepository(listaPrzebojowContext);

            Assert.Empty(artystaRepository.GetAll());
            artystaRepository.Add(new Artysta { ArtystaID = 1, SluchaczeWMiesiacu = 55544, Pseudonim = "Malik Montana" });
            listaPrzebojowContext.SaveChanges();
            Assert.Equal(1,artystaRepository.GetAll().Count());
        }
    }
}
