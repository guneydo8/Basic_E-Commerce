using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class HızlıBakışController : Controller
    {
        // GET: HızlıBakış
        Context db = new Context();
      

        public PartialViewResult Index2()
        {
            var deger = (from x in db.Müşterilers
                         group x by x.MüşteriŞehir into y
                         select new SinifGrup
                         {
                             Şehir = y.Key,
                             Sayi = y.Count()
                         }).ToList().OrderByDescending(t => t.Sayi);

            return PartialView(deger);

        }

        public PartialViewResult personel()
        {

            var deger = (from x in db.Personellers
                         group x by x.Departmanlar.DepartmanAd into y
                         select new personelgrup
                         {
                             Depatman = y.Key,
                             Sayi = y.Count()
                         }).ToList().OrderByDescending(t=>t.Sayi);
            return PartialView(deger);
        }

        public PartialViewResult personelsatiş()
        {
            var deger = (from x in db.Satışlars
                         group x by x.Personeller.PersonelAd+" "+x.Personeller.PersonelSoyad into y
                         select new personelsatış
                         {
                             Personel = y.Key,
                             Sayi = y.Count()
                         }).ToList().OrderByDescending(t=>t.Sayi);

            return PartialView(deger);
        }

        public PartialViewResult ürün()
        {
            //var deger = (from x in db.Ürünlers
            //             group x by x.ÜrünAd into y
            //             select new ÜrünGrup
            //             {
            //                 Ürün = y.Key,
            //                 Sayi = y.Count()
            //             }).ToList();
            //return PartialView(deger);


            var deger = (from x in db.Satışlars
                         group x by x.Ürünler.ÜrünAd
                         into y
                         select new ÜrünGrup
                         {
                             Ürün = y.Key,
                             Sayi = y.Count()
                         }).ToList().OrderByDescending(t=>t.Sayi);
                        
            return PartialView(deger);
        }

        public ActionResult HızlıBakış()
        {
            Class1 bgl = new Class1();
            bgl.mst = db.Müşterilers.Where(x=>x.Durum==true).ToList().OrderByDescending(t=>t.MüşteriId).Take(5);

            bgl.ürn = db.Ürünlers.Where(x => x.Durum == true).ToList().OrderByDescending(t => t.ÜrünId).Take(5);

            bgl.stş = db.Satışlars.ToList().OrderByDescending(t => t.SatışId).Take(7);

            var toplamgelir = db.Satışlars.Sum(x => x.ToplamFiyat);
            var toplammaliyet = db.Ürünlers.Where(x => x.Durum == true).Sum(y => y.AlışFiyat*y.Stok);
            var netkar = db.Satışlars.Sum(x =>x.ToplamFiyat) - (db.Satışlars.Sum(y => y.Ürünler.AlışFiyat*y.Adet));
            var satışhedefi = db.Ürünlers.Where(x => x.Durum == true).Sum(y => y.SatışFiyat*y.Stok);
            bgl.yrm = db.Yorumlars.ToList().OrderByDescending(x=>x.YorumId).Take(5);
            ViewBag.d1 = toplamgelir;
            ViewBag.d2 = toplammaliyet;
            ViewBag.d3 = netkar;
            ViewBag.d4 = satışhedefi;
            return View(bgl);
        } 
      

    }
}