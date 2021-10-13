using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Personeller
    {
        [Key]
        public int PersonelId { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string PersonelAd { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string PersonelSoyad { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(500)]
        public string PersonelFotograf { get; set; }
        public int DepartmanId { get; set; }
        public bool Durum { get; set; }
        public ICollection<Satışlar> Satışlars { get; set; }
        public virtual Departmanlar Departmanlar { get; set; }
    }
}