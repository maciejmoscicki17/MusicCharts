﻿namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IAlbumRepository Albums { get; }
        IPiosenkaRepository Piosenki { get; }
        IArtystaRepository Artyści { get; }
        IPlaylistaRepository Playlisty { get; }
        IChartPiosenekRepository ChartyPiosenek { get; }
        IChartAlbumowRepository ChartyAlbumow { get; }


        void Save();
        void Dispose();
    }
}