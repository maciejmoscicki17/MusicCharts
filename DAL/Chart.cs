using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Chart
    {
        [Key]
        int ChartID { get; set; }
        public virtual ChartPiosenek? chartPiosenek { get; set; }
        public virtual ChartAlbumow? chartAlbumow { get; set; }  
    }
}
