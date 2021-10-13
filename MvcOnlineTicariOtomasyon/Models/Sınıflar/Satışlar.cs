using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Satışlar
    {
        [Key]
        public int SatışId { get; set; }
        public int ÜrünId { get; set; }
        public int PersonelId { get; set; }
        public int MüşteriId { get; set; }


        public virtual Ürünler Ürünler { get; set; }
        public virtual Personeller Personeller { get; set; }
        public  virtual Müşteriler Müşteriler { get; set; }
       
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal ToplamFiyat { get; set; }
        public ICollection<Kargo> Kargos { get; set; }
        public int FaturaId { get; set; }
    }
}