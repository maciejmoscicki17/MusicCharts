using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListaPrzebojow.DAL
{
    [Table("PiosenkaNaPlayliscie")]
    public class PiosenkaNaPlayliscie : IEntityTypeConfiguration<PiosenkaNaPlayliscie>
    {
        [Key]
        public int PiosenkaNaPlayliscieID { get; set; }
        [ForeignKey("PiosenkaID")]
        public int PiosenkaID { get; set; }
        [ForeignKey("PlaylistaID")]
        public int PlaylistaID { get; set; }
        public Piosenka? piosenka { get; set; }
        public Playlista? playlista { get; set; }

        public void Configure(EntityTypeBuilder<PiosenkaNaPlayliscie> builder)
        {
            builder
                .HasOne(p => p.piosenka)
                .WithMany(c => c.PiosenkaNaPlayliscieCol)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(p => p.playlista)
                .WithMany(c => c.PiosenkaNaPlayliscieCol)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
