using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Yorumlar
    {
        [Key]
        public int YorumId { get; set; }
        public int ÜrünId { get; set; }
        public int MüşteriId { get; set; }

        public virtual Ürünler Ürünler { get; set; }
        public virtual Müşteriler Müşteriler { get; set; }

        public DateTime Tarih { get; set; }
        public string İçerik { get; set; }
    }
}