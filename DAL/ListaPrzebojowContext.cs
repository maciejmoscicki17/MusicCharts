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
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MCDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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

            modelBuilder.Entity<Piosenka>()
                .HasOne<Album>(cr => cr.album)
                .WithMany(c => c.piosenkaCol)
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
                new Piosenka { PiosenkaID = 1, IleOdsluchan = 430030716, Nazwa = "Rich Flex", Gatunek = "Rap", AlbumID=1 },
                new Piosenka { PiosenkaID = 2, IleOdsluchan = 128496585, Nazwa = "Major Distribution", Gatunek = "Rap", AlbumID = 1 },
                new Piosenka { PiosenkaID = 3, IleOdsluchan = 128496585, Nazwa = "On BS", Gatunek = "Rap", AlbumID = 1 },
                new Piosenka { PiosenkaID = 4, IleOdsluchan = 76222657, Nazwa = "BackOutsideBoyz", Gatunek = "Rap", AlbumID = 1 },
                new Piosenka { PiosenkaID = 5, IleOdsluchan = 87005583, Nazwa = "Privileged Rappers", Gatunek = "Rap", AlbumID = 1 },
                new Piosenka { PiosenkaID = 6, IleOdsluchan = 87005583, Nazwa = "rockstar", Gatunek = "Rap", AlbumID = 2 },
                new Piosenka { PiosenkaID = 7, IleOdsluchan = 919573559, Nazwa = "Candy Paint", Gatunek = "Rap", AlbumID = 2 },
                new Piosenka { PiosenkaID = 8, IleOdsluchan = 919573559, Nazwa = "Otherside", Gatunek = "Rap", AlbumID = 2 },
                new Piosenka { PiosenkaID = 9, IleOdsluchan = 396452492, Nazwa = "Ball For Me", Gatunek = "Rap", AlbumID = 2 },
                new Piosenka { PiosenkaID = 10, IleOdsluchan = 356452492, Nazwa = "Stay", Gatunek = "Rap", AlbumID = 2 },
                new Piosenka { PiosenkaID = 11, IleOdsluchan = 155198494, Nazwa = "Barbie Dreams", Gatunek = "Rap", AlbumID = 3 },
                new Piosenka { PiosenkaID = 12, IleOdsluchan = 919573559, Nazwa = "Chun-Li", Gatunek = "Rap", AlbumID = 3 },
                new Piosenka { PiosenkaID = 13, IleOdsluchan = 919573559, Nazwa = "Good Form", Gatunek = "Rap", AlbumID = 3 },
                new Piosenka { PiosenkaID = 14, IleOdsluchan = 396452492, Nazwa = "Miami", Gatunek = "Rap", AlbumID = 3 },
                new Piosenka { PiosenkaID = 15, IleOdsluchan = 356452492, Nazwa = "Run & Hide", Gatunek = "Rap", AlbumID = 3 },
                new Piosenka { PiosenkaID = 16, IleOdsluchan = 356453192, Nazwa = "Alice", Gatunek = "Pop", AlbumID = 4 },
                new Piosenka { PiosenkaID = 17, IleOdsluchan = 354553192, Nazwa = "Stupid Love", Gatunek = "Pop", AlbumID = 4 },
                new Piosenka { PiosenkaID = 18, IleOdsluchan = 544553192, Nazwa = "Rain On Me", Gatunek = "Pop", AlbumID = 4 },
                new Piosenka { PiosenkaID = 19, IleOdsluchan = 234553192, Nazwa = "Replay", Gatunek = "Pop", AlbumID = 4 },
                new Piosenka { PiosenkaID = 20, IleOdsluchan = 22153192, Nazwa = "Enigma", Gatunek = "Pop", AlbumID = 4 }
);

            modelBuilder.Entity<Artysta>().HasData(
                new Artysta { ArtystaID = 1, SluchaczeWMiesiacu = 1000, Pseudonim = "Drake" },
                new Artysta { ArtystaID = 2, SluchaczeWMiesiacu = 500, Pseudonim = "21 Savage" },
                new Artysta { ArtystaID = 3, SluchaczeWMiesiacu = 579841, Pseudonim = "Post Malone" },
                new Artysta { ArtystaID = 4, SluchaczeWMiesiacu = 676543, Pseudonim = "Nicki Minaj" },
                new Artysta { ArtystaID = 5, SluchaczeWMiesiacu = 692834, Pseudonim = "Lil Wayne" },
                new Artysta { ArtystaID = 6, SluchaczeWMiesiacu =44355321, Pseudonim = "Lady Gaga" },
                new Artysta { ArtystaID = 7, SluchaczeWMiesiacu =44355321, Pseudonim = "Ariana Grande" }
            );

            modelBuilder.Entity<PiosenkaArtysta>().HasData(
                new PiosenkaArtysta { PiosenkaID = 1, ArtystaID = 1 },
                new PiosenkaArtysta { PiosenkaID = 1, ArtystaID = 2 },
                new PiosenkaArtysta { PiosenkaID = 2, ArtystaID = 2 },
                new PiosenkaArtysta { PiosenkaID = 3, ArtystaID = 1 },
                new PiosenkaArtysta { PiosenkaID = 3, ArtystaID = 2 },
                new PiosenkaArtysta { PiosenkaID = 4, ArtystaID = 1 },
                new PiosenkaArtysta { PiosenkaID = 5, ArtystaID = 1 },
                new PiosenkaArtysta { PiosenkaID = 5, ArtystaID = 2 },
                new PiosenkaArtysta { PiosenkaID = 6, ArtystaID = 2 },
                new PiosenkaArtysta { PiosenkaID = 6, ArtystaID = 3 },
                new PiosenkaArtysta { PiosenkaID = 7, ArtystaID = 3 },
                new PiosenkaArtysta { PiosenkaID = 8, ArtystaID = 3 },
                new PiosenkaArtysta { PiosenkaID = 9, ArtystaID = 3 },
                new PiosenkaArtysta { PiosenkaID = 9, ArtystaID = 4 },
                new PiosenkaArtysta { PiosenkaID = 10, ArtystaID = 3 },
                new PiosenkaArtysta { PiosenkaID = 11, ArtystaID = 4 },
                new PiosenkaArtysta { PiosenkaID = 12, ArtystaID = 4 },
                new PiosenkaArtysta { PiosenkaID = 13, ArtystaID = 4 },
                new PiosenkaArtysta { PiosenkaID = 13, ArtystaID = 5},
                new PiosenkaArtysta { PiosenkaID = 14, ArtystaID = 4 },
                new PiosenkaArtysta { PiosenkaID = 15, ArtystaID = 4 },
                new PiosenkaArtysta { PiosenkaID = 16, ArtystaID = 6 },
                new PiosenkaArtysta { PiosenkaID = 17, ArtystaID = 6 },
                new PiosenkaArtysta { PiosenkaID = 18, ArtystaID = 6 },
                new PiosenkaArtysta { PiosenkaID = 18, ArtystaID = 7 },
                new PiosenkaArtysta { PiosenkaID = 19, ArtystaID = 6 },
                new PiosenkaArtysta { PiosenkaID = 20, ArtystaID = 6 }
            );

            modelBuilder.Entity<Album>().HasData(
                new Album
                {
                    AlbumID = 1,
                    Nazwa = "Her Loss"
                },
                new Album
                {
                    AlbumID = 2,
                    Nazwa = "beerbongs & bentleys"
                },
                new Album
                {
                     AlbumID = 3,
                     Nazwa = "Queen"
                },
                new Album
                {
                     AlbumID = 4,
                     Nazwa = "Chromatica"
                }
            );

            modelBuilder.Entity<ArtystaAlbum>().HasData(
                new ArtystaAlbum { AlbumID = 1, ArtystaID = 1},
                new ArtystaAlbum { AlbumID = 2, ArtystaID = 3},
                new ArtystaAlbum { AlbumID = 3, ArtystaID = 4},
                new ArtystaAlbum { AlbumID = 4, ArtystaID = 6}
                );

            modelBuilder.Entity<Playlista>().HasData(
                new Playlista { PlaylistaID = 1, Nazwa = "Vibe" , Gatunek="Rap"},
                new Playlista { PlaylistaID = 2, Nazwa = "Relax", Gatunek = "Rap" },
                new Playlista { PlaylistaID = 3, Nazwa = "Sunday", Gatunek = "Rap" },
                new Playlista { PlaylistaID = 4, Nazwa = "Girls Night", Gatunek = "Pop" }
                );

            modelBuilder.Entity<PiosenkaNaPlayliscie>().HasData(
                new PiosenkaNaPlayliscie { PlaylistaID = 1, PiosenkaID= 6},
                new PiosenkaNaPlayliscie { PlaylistaID = 1, PiosenkaID= 8},
                new PiosenkaNaPlayliscie { PlaylistaID = 1, PiosenkaID= 9},
                new PiosenkaNaPlayliscie { PlaylistaID = 1, PiosenkaID= 14},
                new PiosenkaNaPlayliscie { PlaylistaID = 1, PiosenkaID=15 },
                new PiosenkaNaPlayliscie { PlaylistaID = 2, PiosenkaID=1 },
                new PiosenkaNaPlayliscie { PlaylistaID = 2, PiosenkaID=3 },
                new PiosenkaNaPlayliscie { PlaylistaID = 2, PiosenkaID= 8},
                new PiosenkaNaPlayliscie { PlaylistaID = 2, PiosenkaID=10 },
                new PiosenkaNaPlayliscie { PlaylistaID = 2, PiosenkaID= 13},
                new PiosenkaNaPlayliscie { PlaylistaID = 3, PiosenkaID =2 },
                new PiosenkaNaPlayliscie { PlaylistaID = 3, PiosenkaID = 4},
                new PiosenkaNaPlayliscie { PlaylistaID = 3, PiosenkaID = 6},
                new PiosenkaNaPlayliscie { PlaylistaID = 3, PiosenkaID =5 },
                new PiosenkaNaPlayliscie { PlaylistaID = 3, PiosenkaID = 12},
                new PiosenkaNaPlayliscie { PlaylistaID = 4, PiosenkaID = 20},
                new PiosenkaNaPlayliscie { PlaylistaID = 4, PiosenkaID = 19},
                new PiosenkaNaPlayliscie { PlaylistaID = 4, PiosenkaID = 18},
                new PiosenkaNaPlayliscie { PlaylistaID = 4, PiosenkaID = 15},
                new PiosenkaNaPlayliscie { PlaylistaID = 4, PiosenkaID = 14}
                 );

            modelBuilder.Entity<Chart>().HasData(
                new Chart { ChartID=1 }
                );

            modelBuilder.Entity<ChartPiosenek>().HasData(
                new ChartPiosenek { ChartPiosenekID = 1 }
                );
            modelBuilder.Entity<ChartAlbumow>().HasData(
                new ChartAlbumow { ChartAlbumowID = 1 }
                );
            modelBuilder.Entity<PiosenkaNaCharcie>().HasData(
                new PiosenkaNaCharcie { PiosenkaID = 1, ChartPiosenekID = 1 },
                new PiosenkaNaCharcie { PiosenkaID = 2, ChartPiosenekID = 1 },
                new PiosenkaNaCharcie { PiosenkaID = 3, ChartPiosenekID = 1 },
                new PiosenkaNaCharcie { PiosenkaID = 4, ChartPiosenekID = 1 },
                new PiosenkaNaCharcie { PiosenkaID = 5, ChartPiosenekID = 1 },
                new PiosenkaNaCharcie { PiosenkaID = 6, ChartPiosenekID = 1 },
                new PiosenkaNaCharcie { PiosenkaID = 7, ChartPiosenekID = 1 },
                new PiosenkaNaCharcie { PiosenkaID = 8, ChartPiosenekID = 1 },
                new PiosenkaNaCharcie { PiosenkaID = 9, ChartPiosenekID = 1 },
                new PiosenkaNaCharcie { PiosenkaID = 10, ChartPiosenekID = 1 },
                new PiosenkaNaCharcie { PiosenkaID = 11, ChartPiosenekID = 1 },
                new PiosenkaNaCharcie { PiosenkaID = 12, ChartPiosenekID = 1 },
                new PiosenkaNaCharcie { PiosenkaID = 13, ChartPiosenekID = 1 },
                new PiosenkaNaCharcie { PiosenkaID = 14, ChartPiosenekID = 1 },
                new PiosenkaNaCharcie { PiosenkaID = 15, ChartPiosenekID = 1 },
                new PiosenkaNaCharcie { PiosenkaID = 16, ChartPiosenekID = 1 },
                new PiosenkaNaCharcie { PiosenkaID = 17, ChartPiosenekID = 1 },
                new PiosenkaNaCharcie { PiosenkaID = 18, ChartPiosenekID = 1 },
                new PiosenkaNaCharcie { PiosenkaID = 19, ChartPiosenekID = 1 },
                new PiosenkaNaCharcie { PiosenkaID = 20, ChartPiosenekID = 1 }
                );
            modelBuilder.Entity<AlbumNaCharcie>().HasData(
                new AlbumNaCharcie { ChartAlbumowID = 1, AlbumID = 1},
                new AlbumNaCharcie { ChartAlbumowID = 1, AlbumID = 2},
                new AlbumNaCharcie { ChartAlbumowID = 1, AlbumID = 3},
                new AlbumNaCharcie { ChartAlbumowID = 1, AlbumID = 4}
                );


        }
    }
}
