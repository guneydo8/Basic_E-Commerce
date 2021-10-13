using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Faturalar
    {
        [Key]
        public int FaturaId { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string FaturaSeriNo { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string FaturaSıraNo { get; set; }
        public DateTime Tarih { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string VergiDairesi { get; set; }


        public int MüşteriId { get; set; }
        public virtual Müşteriler Müşteriler { get; set; }


        public decimal Toplam { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}