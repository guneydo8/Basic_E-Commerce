using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Departmanlar
    {
        [Key]
        public int DepartmanId { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public String DepartmanAd { get; set; }
        public bool Durum { get; set; }

        


        public ICollection<Personeller> Personellers { get; set; }


    }
}