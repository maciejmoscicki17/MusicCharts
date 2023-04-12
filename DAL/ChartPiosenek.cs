using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("ChartPiosenek")]
    public class ChartPiosenek
    {
        [Key]
        [ForeignKey("ChartID")]
        public int ChartPiosenekID { get; set; }
        public string Nazwa { get; set; }
        public ICollection<Piosenka>? piosenki { get; set; }
        public virtual ICollection<PiosenkaNaCharcie>? PiosenkaNaCharcieCol { get; set; }
        public virtual Chart chart { get; set; }


    }
}
