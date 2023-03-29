using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("PiosenkaArtysta")]
    public class PiosenkaArtysta
    {
        [ForeignKey("Artysta")]
        public int ArtystaID { get; set; }
        [ForeignKey("Piosenka")]
        public int PiosenkaID { get; set; }
        public Artysta artysta { get; set; }
        public Piosenka piosenka { get; set; }
    }
}
