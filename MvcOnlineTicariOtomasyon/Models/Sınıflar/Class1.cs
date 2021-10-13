using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Class1
    {
        public IEnumerable<Ürünler> ürn { get; set; }
        public IEnumerable<Ürünler> ürn2 { get; set; }
    
        public IEnumerable<Yorumlar> yrm { get; set; }
        public IEnumerable<Müşteriler> mst { get; set; }
        public IEnumerable<Satışlar> stş { get; set; }
        public IEnumerable<TodoList> todo { get; set; }
        public IEnumerable<Kategori> ktg { get; set; }
        public IEnumerable<Kategori> ktg2 { get; set; }
        public IEnumerable<Favorilerim> fvr { get; set; }
        public IEnumerable<Favorilerim> fvr2 { get; set; }
        public IEnumerable<Sepetim> spt { get; set; }
        public IEnumerable<Faturalar> ftr { get; set; }
        public IEnumerable<FaturaKalem> ftrklm { get; set; }
        
    }
}