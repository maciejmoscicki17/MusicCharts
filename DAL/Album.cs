using ListaPrzebojow.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("Album")]
    public class Album : IEntityTypeConfiguration<Album>
    {
        [Key]
       public  int AlbumID { get; set; }
        [ForeignKey("PiosenkaID")]
        public int PiosenkaID { get; }
        public string Nazwa { get; set; }
        public Piosenka? Piosenki { get; set; }
        public ICollection<Artysta>? ArtysciCol { get; set; }
        public  ICollection<AlbumNaCharcie>? AlbumNaCharcieCol { get; set; }

        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder
         .HasOne(p => p.Piosenki)
         .WithMany(c => c.AlbumCol)
         .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
