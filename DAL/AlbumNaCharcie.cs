using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListaPrzebojow.DAL
{
    [Table("AlbumNaCharcie")]
    public class AlbumNaCharcie
    {

        [ForeignKey("ChartAlbumowID")]
        public int ChartAlbumowID { get; set; }
        [ForeignKey("AlbumID")]
        public int AlbumID { get; set; }
        public Album album { get; set; }
        public ChartAlbumow chartAlbumow { get; set; }
    }
}
