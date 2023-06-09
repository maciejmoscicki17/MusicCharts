﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("Chart")]
    public class Chart
    {
        [Key]
        public int ChartID { get; set; }
        public string Nazwa { get; set; }
        public virtual ChartPiosenek chartPiosenek { get; set; }
        public virtual ChartAlbumow chartAlbumow { get; set; }  
    }
}
