using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }


        [Column(TypeName ="varchar")]
        [StringLength(30)]
        public string KullanıcıAd { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string Şifre { get; set; }



        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string Yetki { get; set; }
    }
}