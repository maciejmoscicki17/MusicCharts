using DAL.Interfaces;
using DAL.Repositories;
using ListaPrzebojow.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectBLL
{
    internal class TestUnitOfWork : IUnitOfWork
    {
        private readonly ListaPrzebojowContext _context;

        public IAlbumRepository Albums { get; private set; }
        public IPiosenkaRepository Piosenki { get; private set; }
        public IArtystaRepository Artyści { get; private set; }
        public IPlaylistaRepository Playlisty { get; private set; }
        public IChartPiosenekRepository ChartyPiosenek { get; private set; }
        public IChartAlbumowRepository ChartyAlbumow { get; private set; }
        public IArtystaAlbumRepository artystaAlbum { get; private set; }
        public IPiosenkaArtystaRepository piosenkaArtysta { get; private set; }
        public IPlaylistaPiosenkaRepository playlistaPiosenka { get; private set; }
        public IPiosenkaNaCharcieRepository piosenkaNaCharcie { get; private set; }
        public IAlbumNaCharcieRepository albumNaCharcie { get; private set; }


        public TestUnitOfWork(ListaPrzebojowContext context, IChartPiosenekRepository? chartPiosenek = null, IAlbumRepository? albumRepository = null, IPiosenkaRepository? piosenkaRepository = null)
        {
            _context = context;
            Albums = albumRepository ?? new AlbumRepository(_context);
            Piosenki = piosenkaRepository ?? new PiosenkaRepository(_context);
            Artyści = new ArtystaRepository(_context);
            Playlisty = new PlaylistaRepository(_context);
            ChartyAlbumow = new ChartAlbumowRepository(_context);
            ChartyPiosenek = chartPiosenek ?? new ChartPiosenekRepository(_context);
            artystaAlbum = new ArtystaAlbumRepository(_context);
            piosenkaArtysta = new PiosenkaArtystaRepository(_context);
            playlistaPiosenka = new PlaylistaPiosenkaRepository(_context);
            piosenkaNaCharcie = new PiosenkaNaCharcieRepository(_context);
            albumNaCharcie = new AlbumNaCharcieRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
