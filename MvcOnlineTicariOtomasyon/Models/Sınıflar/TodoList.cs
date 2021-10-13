using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class TodoList
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string İçerik { get; set; }


        [Column(TypeName ="SmallDateTime")]
        public DateTime Tarih { get; set; }


        [Column(TypeName = "bit")]
        public bool Durum { get; set; }
       
    }
}