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
        [ForeignKey("Artysta")]
        public int ArtystaID { get; set; }
        public string Nazwa { get; set; }
        public virtual Artysta Artysta { get; set; }
        public virtual ICollection<AlbumNaCharcie> AlbumNaCharcieCol { get; set; }
        public virtual ICollection<Piosenka> piosenkiCol { get; set; }
        public virtual ICollection<Artysta> artystaCol { get; set; }

    }
}
