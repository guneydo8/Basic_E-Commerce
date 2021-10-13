using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KullanıcıFavoriController : Controller
    {
        // GET: KullanıcıFavori
        Context db = new Context();
        Class1 bgl = new Class1();
        public ActionResult Index()
        {
            return View();
        }


        public PartialViewResult favori()
        {
            var mail = Session["Mail"].ToString();
            var musteri = db.Müşterilers.FirstOrDefault(y => y.MüşteriMail == mail);
            bgl.mst = db.Müşterilers.Where(t => t.MüşteriId == musteri.MüşteriId).ToList();

            var deger1 = db.Satışlars.Where(x => x.MüşteriId == musteri.MüşteriId).Count();
            var deger5 = db.Favorilerims.Where(x => x.MüşteriId == musteri.MüşteriId).Count();
            var deger6 = db.Sepetims.Where(x => x.MüşteriId == musteri.MüşteriId).Count();
            var deger2 = db.Yorumlars.Where(x => x.MüşteriId == musteri.MüşteriId).Count();
           
            var deger4 = db.Satışlars.Where(x => x.MüşteriId == musteri.MüşteriId).OrderByDescending(t=>t.Tarih).Select(y => y.Ürünler.ÜrünAd).FirstOrDefault();


            bgl.stş = db.Satışlars.Where(x => x.MüşteriId == musteri.MüşteriId).ToList();

            if (deger1 != 0)
            {
                var deger3 = db.Satışlars.Where(x => x.MüşteriId == musteri.MüşteriId).Sum(y=>y.ToplamFiyat).ToString();
                ViewBag.d3 = deger3;

            }


            if (deger1 == 0)
            {
               
                ViewBag.d3 = 0;

            }

            if (deger4 != null)
            {
                ViewBag.d4 = deger4;
            }
            if (deger4 == null)
            {
                ViewBag.d4 = "Siparişiniz Yok";
            }

            ViewBag.d1 = deger1;
            ViewBag.d2 = deger2;
            
           
            ViewBag.d5 = deger5;
            ViewBag.d6 = deger6;
            
          
            return PartialView(bgl);
        }

        public ActionResult favori2(int id)
        {
            var bul = db.Favorilerims.Find(id);
            ViewBag.id = bul;
            return View();

        }


        public ActionResult FavoriListe()
        {
            var mail = Session["Mail"].ToString();
            var musteri = db.Müşterilers.FirstOrDefault(y => y.MüşteriMail == mail);
            bgl.fvr = db.Favorilerims.Where(t => t.MüşteriId == musteri.MüşteriId).ToList();
            return View(bgl);
        }

       
    }
}