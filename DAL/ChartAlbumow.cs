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
    public class ChartAlbumow
    {

        [Key]
        [ForeignKey("ChartID")]
        public int ChartAlbumowID { get;set; }
        public ICollection<Album>? albumy { get; set; }
        public virtual Chart chart { get; set; }
        public virtual ICollection<AlbumNaCharcie>? AlbumNaCharcieCol { get; set; }
    }
}
