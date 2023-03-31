using ListaPrzebojow.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("Album")]
    public class Album
    {
        [Key]
       public  int AlbumID { get; set; }
        public string Nazwa { get; set; }
        public virtual ICollection<AlbumNaCharcie>? AlbumNaCharcieCol { get; set; }
        public virtual ICollection<ArtystaAlbum>? artystaAlbumCol { get; set; }
        public virtual ICollection<Piosenka>? piosenkaCol { get; set; }

    }
}
