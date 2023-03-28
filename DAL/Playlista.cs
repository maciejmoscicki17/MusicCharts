using ListaPrzebojow.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("Playlista")]
    public class Playlista
    {
        [Key]
        public int PlaylistaID { get; set; }
        public ICollection<Piosenka> piosenkaCol { get; set; }
        public ICollection<PiosenkaNaPlayliscie> PiosenkaNaPlayliscieCol { get; set; }
        public string Gatunek { get; set; }
    }
}
