using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListaPrzebojow.DAL
{
    [Table("PiosenkaNaPlayliscie")]
    public class PiosenkaNaPlayliscie
    {
        [ForeignKey("Piosenka")]
        public int PiosenkaID { get; set; }
        [ForeignKey("Playlista")]
        public int PlaylistaID { get; set; }
        public Piosenka piosenka { get; set; }
        public Playlista playlista { get; set; }
    }
}
