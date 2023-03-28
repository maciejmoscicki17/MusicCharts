using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("Artysta")]
    public class Artysta : IEntityTypeConfiguration<Artysta>
    {
        [Key]
        public int ArtystaID { get; private set; }
        [ForeignKey("AlbumID")]
        public int AlbumID { get; set; }
        public ICollection<Album>? Albumy { get; set; }
        public Album? album { get; set; }
        public Artysta? artysta { get; set; }
        int SluchaczeWMiesiacu { get; set; }
        string Pseudonim { get; set; }

        public void Configure(EntityTypeBuilder<Artysta> builder)
        {
            builder
                .HasOne(p => p.album)
                .WithMany(c => c.ArtysciCol)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
