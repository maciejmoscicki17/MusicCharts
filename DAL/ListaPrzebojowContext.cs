using DAL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System;
using System.Reflection;

namespace ListaPrzebojow.DAL
{
    public class ListaPrzebojowContext : DbContext
    {
        public virtual DbSet<Piosenka> piosenkaDb { get; set; }
        public virtual DbSet<PiosenkaNaCharcie> piosenkaNaCharcieDb { get; set; }
        public virtual DbSet<ChartPiosenek> chartPiosenekDb { get; set; }
        public virtual DbSet<PiosenkaNaPlayliscie> piosenkaNaPlayliscieDb { get; set; }
        public virtual DbSet<Playlista> playlistaDb { get; set; }
        public virtual DbSet<Chart> chartDb { get; set; }
        public virtual DbSet<Artysta> artystaDb { get; set; }
        public virtual DbSet<Album> albumDb { get; set; }
        public virtual DbSet<AlbumNaCharcie> albumNaCharcieDb { get; set; }
        public virtual DbSet<ChartAlbumow> chartAlbumowDb { get; set; }
        public  DbSet<ArtystaAlbum> artystaAlbumDb { get; set; }
        public  DbSet<PiosenkaArtysta> piosenkaArtystaDb { get; set; }

        public ListaPrzebojowContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MCDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<PiosenkaNaCharcie>().HasKey(ep => new { ep.PiosenkaID, ep.ChartPiosenekID });
            modelBuilder.Entity<PiosenkaNaPlayliscie>().HasKey(ep => new { ep.PiosenkaID, ep.PlaylistaID });
            modelBuilder.Entity<AlbumNaCharcie>().HasKey(ep => new { ep.AlbumID, ep.ChartAlbumowID });
            modelBuilder.Entity<PiosenkaArtysta>().HasKey(ep => new { ep.PiosenkaID, ep.ArtystaID });
            modelBuilder.Entity<ArtystaAlbum>().HasKey(ep => new { ep.AlbumID, ep.ArtystaID });

            modelBuilder.Entity<PiosenkaNaCharcie>()
                .HasOne<Piosenka>(cr => cr.piosenka)
                .WithMany(c => c.PiosenkaNaCharcieCol)
                .HasForeignKey(cr => cr.PiosenkaID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PiosenkaNaCharcie>()
                .HasOne<ChartPiosenek>(cr => cr.chartPiosenek)
                .WithMany(r => r.PiosenkaNaCharcieCol)
                .HasForeignKey(cr => cr.ChartPiosenekID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PiosenkaNaPlayliscie>()
                .HasOne<Piosenka>(cr => cr.piosenka)
                .WithMany(c => c.PiosenkaNaPlayliscieCol)
                .HasForeignKey(cr => cr.PiosenkaID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PiosenkaNaPlayliscie>()
                .HasOne<Playlista>(cr => cr.playlista)
                .WithMany(r => r.PiosenkaNaPlayliscieCol)
                .HasForeignKey(cr => cr.PlaylistaID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AlbumNaCharcie>()
                .HasOne<Album>(cr => cr.album)
                .WithMany(c => c.AlbumNaCharcieCol)
                .HasForeignKey(cr => cr.AlbumID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AlbumNaCharcie>()
                .HasOne<ChartAlbumow>(cr => cr.chartAlbumow)
                .WithMany(r => r.AlbumNaCharcieCol)
                .HasForeignKey(cr => cr.ChartAlbumowID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            //wiele do wielu artysta album
            modelBuilder.Entity<ArtystaAlbum>()
                .HasOne<Album>(cr => cr.album)
                .WithMany(c => c.artystaAlbumCol)
                .HasForeignKey(cr => cr.AlbumID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ArtystaAlbum>()
                .HasOne<Artysta>(cr => cr.artysta)
                .WithMany(c => c.artystaAlbumCol)
                .HasForeignKey(cr => cr.ArtystaID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            //wiele do wielu artysta piosenka
            modelBuilder.Entity<PiosenkaArtysta>()
                .HasOne<Artysta>(cr => cr.artysta)
                .WithMany(c => c.piosenkaArtystaCol)
                .HasForeignKey(cr => cr.ArtystaID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PiosenkaArtysta>()
                .HasOne<Piosenka>(cr => cr.piosenka)
                .WithMany(c => c.piosenkaArtystaCol)
                .HasForeignKey(cr => cr.PiosenkaID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Chart>()
                .HasOne(c => c.chartPiosenek)
                .WithOne(r => r.chart)
                .HasForeignKey<ChartPiosenek>(b => b.ChartPiosenekID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Chart>()
                .HasOne(c => c.chartAlbumow)
                .WithOne(r => r.chart)
                .HasForeignKey<ChartAlbumow>(b => b.ChartAlbumowID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Piosenka>().HasData(
                new Piosenka { PiosenkaID = 1, IleOdsluchan = 100, Nazwa = "Piosenka 1", Gatunek = "Rock" },
                new Piosenka { PiosenkaID = 2, IleOdsluchan = 50, Nazwa = "Piosenka 2", Gatunek = "Pop" }
);

            modelBuilder.Entity<Artysta>().HasData(
                new Artysta { ArtystaID = 1, SluchaczeWMiesiacu = 1000, Pseudonim = "Artysta 1" },
                new Artysta { ArtystaID = 2, SluchaczeWMiesiacu = 500, Pseudonim = "Artysta 2" }
            );

            modelBuilder.Entity<PiosenkaArtysta>().HasData(
                new PiosenkaArtysta { PiosenkaID = 1, ArtystaID = 1 },
                new PiosenkaArtysta { PiosenkaID = 2, ArtystaID = 2 }
            );

            //modelBuilder.Entity<Album>()
            //    .HasData(
            //        new Album { AlbumID = 1, ArtystaID = 1, Nazwa = "2014 Forest Hills Drive" },
            //        new Album { AlbumID = 2, ArtystaID = 1, Nazwa = "Album 2" },
            //        new Album { AlbumID = 3, ArtystaID = 2, Nazwa = "Album 3" }
            //    );

            //modelBuilder.Entity<Artysta>()
            //    .HasData(
            //        new Artysta { ArtystaID = 1, SluchaczeWMiesiacu = 1000, Pseudonim = "J.Cole" },
            //        new Artysta { ArtystaID = 2, SluchaczeWMiesiacu = 500, Pseudonim = "Artysta 2" }
            //    );
            //modelBuilder.Entity<Chart>()
            //    .HasData(
            //        new Chart { ChartID = 1 }
            //    );

            //modelBuilder.Entity<ChartAlbumow>()
            //    .HasData(
            //        new ChartAlbumow { ChartAlbumowID = 1, ChartID = 1 }
            //    );

            //modelBuilder.Entity<ChartPiosenek>()
            //    .HasData(
            //        new ChartPiosenek { ChartPiosenekID = 1, ChartID = 1 }
            //    );

            //modelBuilder.Entity<Piosenka>()
            //    .HasData(
            //        new Piosenka { PiosenkaID = 1, ArtystaID = 1, AlbumID = 1, Nazwa = "No Role Modelz", Gatunek = "Rap", IleOdsluchan=20044 },
            //        new Piosenka { PiosenkaID = 2, ArtystaID = 1, AlbumID = 1, Nazwa = "Piosenka 2", Gatunek = "Rock", IleOdsluchan = 300 },
            //        new Piosenka { PiosenkaID = 3, ArtystaID = 2, AlbumID = 3, Nazwa = "Piosenka 3", Gatunek = "Pop", IleOdsluchan = 4000 }
            //    );

            //modelBuilder.Entity<Playlista>()
            //    .HasData(
            //        new Playlista { PlaylistaID = 1, Gatunek = "Rock" }
            //    );

        }
    }
}
