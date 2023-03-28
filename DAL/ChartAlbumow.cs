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
    [Table("ChartAlbumow")]
    public class ChartAlbumow : Chart
    {
       
        [Key]
        public int ChartAlbumowID { get; private set; }
        [ForeignKey("ChartID")]
        int ChartID { get; set; }
        ICollection<Album>? albumy { get; set; }
       // public virtual Chart? chart { get; set; }
        public ICollection<AlbumNaCharcie>? AlbumNaCharcieCol { get; set; }
    }
}
