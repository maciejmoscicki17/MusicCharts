using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("ArtystaAlbum")]
    public class ArtystaAlbum
    {
        [ForeignKey("Artysta")]
        public int ArtystaID { get; set; }
        [ForeignKey("Album")]
        public int AlbumID { get; set; }
        public Album album { get; set; }
        public Artysta artysta { get; set; }

    }
}
