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
        public int ChartPiosenekID { get; set; }
        public ICollection<Piosenka> piosenki { get; set; }
        public virtual ICollection<PiosenkaNaCharcie> PiosenkaNaCharcieCol { get; set; }
        [ForeignKey("ChartID")]
        public int ChartID { get; set; }
        public virtual Chart chart { get; set; }


    }
}
