using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class KargoTakip
    {
        [Key]
        public int KargotakipId { get; set; }

        public int KargoId { get; set; }


        public virtual Kargo Kargo { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(500)]
        public string Açıklama { get; set; }
        public DateTime Tarih { get; set; }
    }
}