using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Kargo
    {
        [Key]
        public int KargoId { get; set; }
        public int SatışId { get; set; }
        public virtual Satışlar Satışlar { get; set; }
        public string TakipKodu { get; set; }
        public DateTime Tarih { get; set; }

    }
}