using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Ürünler
    {
        [Key]
        public int ÜrünId { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string ÜrünAd { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Marka { get; set; }
      
        public string ÜrünBilgi { get; set; }
        public int Stok { get; set; }
        public decimal AlışFiyat { get; set; }
        public decimal SatışFiyat { get; set; }
        public bool Durum { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(500)]
        public string ÜrünGörsel { get; set; }

        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
        public ICollection<Satışlar>  Satışlars { get; set; }
        public ICollection<Yorumlar>  Yorumlars { get; set; }
        public ICollection<FaturaKalem>  FaturaKalems { get; set; }

    }
}