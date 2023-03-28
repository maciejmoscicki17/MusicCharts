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
    public class Artysta
    {
        [Key]
        public int ArtystaID { get; set; }
        //public virtual Album album { get; set; }
        public virtual ICollection<Album> album { get; set; }
        public int SluchaczeWMiesiacu { get; set; }
        public string Pseudonim { get; set; }
    }
}
