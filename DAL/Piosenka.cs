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
        public int IleOdsluchan { get; set; }
        public int IleOdsluchanTydzien { get; set; }
        public string Nazwa { get; set; }
        public string Gatunek { get; set; }
        public virtual ICollection<PiosenkaNaCharcie>? PiosenkaNaCharcieCol { get; set; }
        public virtual ICollection<PiosenkaNaPlayliscie>? PiosenkaNaPlayliscieCol { get; set; }
        public virtual ICollection<PiosenkaArtysta>? piosenkaArtystaCol { get; set; }
        public virtual Album?  album { get; set; }

    }
}