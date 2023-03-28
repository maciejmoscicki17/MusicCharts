using ListaPrzebojow.DAL;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    [Table("Piosenka")]
    public class Piosenka
    {
        [Key]
        public int PiosenkaID { get; set; }
        [ForeignKey("Album")]
        public int AlbumID { get; set; }
        [ForeignKey("Artysta")]
        public int ArtystaID { get; set; }
        public int IleOdsluchan { get; set; }
        public Artysta Artysta { get; set; }
        public Album Album { get; set; }
        public string Nazwa { get; set; }
        public string Gatunek { get; set; }
        public virtual ICollection<PiosenkaNaCharcie> PiosenkaNaCharcieCol { get; set; }
        public virtual ICollection<PiosenkaNaPlayliscie> PiosenkaNaPlayliscieCol { get; set; }
        public ICollection<Album>   AlbumCol { get; set; }

    }
}