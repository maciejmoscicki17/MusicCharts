using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("PiosenkaNaCharcie")]
    public class PiosenkaNaCharcie : IEntityTypeConfiguration<PiosenkaNaCharcie>
    {
        [ForeignKey("PiosenkaID")]
       public int PiosenkaID { get; set; }
        [ForeignKey("ChartPiosenekID")]
        public int ChartPiosenekID { get; set; }
        [Key]
        public int ChartID { get; set; }
        int PozycjaPiosenki { get; set; }
        public Piosenka? piosenka { get; set; }
        public ChartPiosenek? chartPiosenek { get; set; }

        public void Configure(EntityTypeBuilder<PiosenkaNaCharcie> builder)
        {
            builder
                .HasOne(p => p.piosenka)
                .WithMany(c => c.PiosenkaNaCharcieCol)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(p => p.chartPiosenek)
                .WithMany(c => c.PiosenkaNaCharcieCol)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
