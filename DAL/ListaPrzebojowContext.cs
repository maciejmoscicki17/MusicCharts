using DAL;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ListaPrzebojow.DAL
{
    public class ListaPrzebojowContext : DbContext
    {
        public DbSet<Piosenka> piosenkaDb { get; set; }
        public DbSet<PiosenkaNaCharcie> piosenkaNaCharcieDb { get; set; }
        public DbSet<ChartPiosenek> chartPiosenekDb { get; set; }
        public DbSet<PiosenkaNaPlayliscie> piosenkaNaPlayliscieDb { get; set; }
        public DbSet<Playlista> playlistaDb { get; set; }
        public DbSet<Artysta> artystaDb { get; set; }
        public DbSet<Album> albumDb { get; set; }
        public DbSet<AlbumNaCharcie> albumNaCharcieDb { get; set; }
        public DbSet<ChartAlbumow> chartAlbumowDb { get; set; }

        public ListaPrzebojowContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ListaPrzebojowDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.Entity<PiosenkaNaCharcie>()
            //    .HasRequired<Piosenka>(s => s.piosenka)
            //    .WithMany(g => g.PiosenkaNaCharcieCol)
            //    .HasForeignKey<int>(s => s.PiosenkaID);

            //modelBuilder.Entity<PiosenkaNaCharcie>()
            //    .HasRequired<ChartPiosenek>(s => s.chartPiosenek)
            //    .WithMany(g => g.PiosenkaNaCharcieCol)
            //    .HasForeignKey<int>(s => s.ChartPiosenekID);

            //modelBuilder.Entity<AlbumNaCharcie>()
            //    .HasRequired<Album>(s => s.album)
            //    .WithMany(g => g.AlbumNaCharcieCol)
            //    .HasForeignKey<int>(s => s.AlbumID);

            //modelBuilder.Entity<AlbumNaCharcie>()
            //    .HasRequired<ChartAlbumow>(s => s.chartAlbumow)
            //    .WithMany(g => g.AlbumNaCharcieCol)
            //    .HasForeignKey<int>(s => s.ChartAlbumowID);

            //modelBuilder.Entity<Album>()
            //    .HasRequired<Piosenka>(s => s.Piosenki)
            //    .WithMany(g => g.AlbumCol)
            //    .HasForeignKey<int>(s => s.PiosenkaID);

            //modelBuilder.Entity<Artysta>()
            //    .HasRequired<Album>(s => s.album)
            //    .WithMany(g => g.ArtysciCol)
            //    .HasForeignKey<int>(s => s.AlbumID);

            //modelBuilder.Entity<PiosenkaNaPlayliscie>()
            //    .HasRequired<Piosenka>(s => s.piosenka)
            //    .WithMany(g => g.PiosenkaNaPlayliscieCol)
            //    .HasForeignKey<int>(s => s.PiosenkaID);

            //modelBuilder.Entity<PiosenkaNaPlayliscie>()
            //    .HasRequired<Playlista>(s => s.playlista)
            //    .WithMany(g => g.PiosenkaNaPlayliscieCol)
            //    .HasForeignKey<int>(s => s.PlaylistaID);

            //modelBuilder.Entity<Chart>()
            //   .HasOptional(s => s.chartPiosenek)
            //   .WithRequired(ad => ad.chart);

            //modelBuilder.Entity<Chart>()
            //   .HasOptional(s => s.chartAlbumow)
            //   .WithRequired(ad => ad.chart);
        }
    }
}
