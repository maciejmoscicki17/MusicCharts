using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListaPrzebojow.DAL
{
    public class AlbumNaCharcie : IEntityTypeConfiguration<AlbumNaCharcie>
    {
        [Key]
        public int AlbumNaCharcieID { get; set; }

        [ForeignKey("ChartAlbumowID")]
        public int ChartAlbumowID { get; set; }
        [ForeignKey("AlbumID")]
        public int AlbumID { get; set; }
        public Album? album { get; set; }
        public ChartAlbumow? chartAlbumow { get; set; }

        public void Configure(EntityTypeBuilder<AlbumNaCharcie> builder)
        {
            builder
                .HasOne(p => p.album)
                .WithMany(c => c.AlbumNaCharcieCol)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(p => p.chartAlbumow)
                .WithMany(c => c.AlbumNaCharcieCol)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
