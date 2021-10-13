using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Context:DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Departmanlar> Departmanlars { get; set; }
        public DbSet<Faturalar> Faturalars { get; set; }
        public DbSet<FaturaKalem> FaturaKalems { get; set; }
      
        public DbSet<Giderler> Giderlers { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Müşteriler> Müşterilers { get; set; }
        public DbSet<Personeller> Personellers { get; set; }
        public DbSet<Satışlar> Satışlars { get; set; }
        public DbSet<Ürünler> Ürünlers { get; set; }
        public DbSet<Yorumlar> Yorumlars { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<Sepetim> Sepetims { get; set; }

      
        public DbSet<Favorilerim> Favorilerims { get; set; }
        public DbSet<Kargo> Kargos { get; set; }
        public DbSet<KargoTakip> KargoTakips { get; set; }
        public DbSet<Mesajlar> Mesajlars { get; set; }
        public DbSet<Duyuru> Duyurus { get; set; }
    }
}