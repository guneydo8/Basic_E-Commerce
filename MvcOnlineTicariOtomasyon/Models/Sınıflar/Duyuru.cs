using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Duyuru
    {
        [Key]
        public int DuyuruId { get; set; }
        public string Konu { get; set; }
        public string İçerik { get; set; }
        public DateTime Tarih { get; set; }
    }
}