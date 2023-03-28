using ListaPrzebojow.DAL;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class Piosenka
    {
        [Key]
        public int PiosenkaID { get; }
        int IleOdsluchan { get; set; }
        [Required]
        Artysta? Artysta { get; set; }
        Album? Album { get; set; }
        string Nazwa { get; set; }
        string Gatunek { get; set; }
        public ICollection<PiosenkaNaCharcie>? PiosenkaNaCharcieCol { get; set; }
        public ICollection<PiosenkaNaPlayliscie>? PiosenkaNaPlayliscieCol { get; set; }
        public ICollection<Album>?   AlbumCol { get; set; }

    }
}