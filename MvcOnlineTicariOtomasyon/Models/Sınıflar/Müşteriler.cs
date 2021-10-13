using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Müşteriler
    {
        [Key]
        public int MüşteriId { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string MüşteriAd { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string MüşteriSoyad { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string MüşteriŞehir { get; set; }
        public string MüşteriŞifre { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string MüşteriMail { get; set; }

        public string MüşteriFotograf { get; set; }

        public bool Durum { get; set; }
        public ICollection<Satışlar> Satışlars { get; set; }
        public ICollection<Yorumlar> Yorumlars { get; set; }
        public ICollection<Faturalar> Faturalars { get; set; }
       
      
    }
}