﻿using DAL.Interfaces;
using DAL.Repositories;

namespace ListaPrzebojow.DAL
{
    public class UnitOfWork
    {
        private readonly ListaPrzebojowContext _context;

        public IAlbumRepository Albums { get; private set; }
        public IPiosenkaRepository Piosenki { get; private set; }
        public IArtystaRepository Artyści { get; private set; }
        public IPlaylistaRepository Playlisty { get; private set; }
        public IChartPiosenekRepository ChartyPiosenek { get; private set; }
        public IChartAlbumowRepository ChartyAlbumow { get; private set; }

        public UnitOfWork(ListaPrzebojowContext context)
        {
            _context = context;
            Albums = new AlbumRepository(_context);
            Piosenki = new PiosenkaRepository(_context);
            Artyści = new ArtystaRepository(_context);
            Playlisty = new PlaylistaRepository(_context);
            ChartyAlbumow = new ChartAlbumowRepository(_context);
            ChartyPiosenek = new ChartPiosenekRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}