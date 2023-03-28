﻿using ListaPrzebojow.DAL;
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
        public int PlaylistaID { get; private set; }
        [Required]
        ICollection<Piosenka>? piosenkaList { get; set; }
        public ICollection<PiosenkaNaPlayliscie>? PiosenkaNaPlayliscieCol { get; set; }
        string Gatunek { get; set; }
    }
}
