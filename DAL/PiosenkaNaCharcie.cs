using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("PiosenkaNaCharcie")]
    public class PiosenkaNaCharcie
    {
        [ForeignKey("Piosenka")]
        public int PiosenkaID { get; set; }
        [ForeignKey("ChartPiosenek")]
        public int ChartPiosenekID { get; set; }
        public int PozycjaPiosenki { get; set; }
        public Piosenka piosenka { get; set; }
        public ChartPiosenek chartPiosenek { get; set; }
    }
}
