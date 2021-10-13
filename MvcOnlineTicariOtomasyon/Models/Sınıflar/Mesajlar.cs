using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Mesajlar
    {

        [Key]
        public int MesajId { get; set; }
       
        public string Gönderen { get; set; }
        public string Alıcı { get; set; }
        public DateTime Tarih { get; set; }
        public string Konu { get; set; }
        public string İçerik { get; set; }
    }
}