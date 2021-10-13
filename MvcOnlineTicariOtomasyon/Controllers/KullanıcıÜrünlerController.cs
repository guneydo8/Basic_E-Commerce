using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KullanıcıÜrünlerController : Controller
    {
        // GET: KullanıcıÜrünler
        Context db = new Context();
        Class1 bgl = new Class1();
        public ActionResult Index()
        {
            bgl.ktg = db.Kategoris.ToList();
            bgl.ürn = db.Ürünlers.Where(x=>x.Durum==true).ToList();
            var deger = db.Ürünlers.Where(x => x.Durum == true).Count();
            ViewBag.d1 = deger;
            
            return View(bgl);
        }


        public ActionResult ÜrünDetay(int id)
        {

            bgl.ürn = db.Ürünlers.Where(x => x.ÜrünId == id).ToList();

            //var mail = Session["Mail"].ToString();
            //var müsteri = db.Müşterilers.FirstOrDefault(x => x.MüşteriMail == mail);


            bgl.yrm = db.Yorumlars.Where(x => x.ÜrünId == id ).ToList();
            var ürün = db.Ürünlers.Find(id);
            ViewBag.d1 = ürün.ÜrünId;

            return View(bgl);
        }

        [HttpPost]
        public ActionResult ÜrünDetay(Yorumlar x)
        {
            var mail=Session["Mail"].ToString();
            var müsteri = db.Müşterilers.FirstOrDefault(y => y.MüşteriMail == mail);
            db.Yorumlars.Add(x);
            x.MüşteriId = müsteri.MüşteriId;
            x.Tarih = DateTime.Parse(DateTime.Now.ToString());
            db.SaveChanges();
            return RedirectToAction("ÜrünDetay");

        }
      
        public ActionResult FavoriEkle(int id)
        {
            var mail = Session["Mail"].ToString();
            var musteri = db.Müşterilers.FirstOrDefault(y => y.MüşteriMail == mail);
            Favorilerim x = new Favorilerim();
            x.MüşteriId = musteri.MüşteriId;
            x.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            x.ÜrünId = id;
            db.Favorilerims.Add(x);
          
            
            db.SaveChanges();
            return RedirectToAction("FavoriListe", "KullanıcıFavori");
        }

        public ActionResult FavoriÇıkar(int id)
        {
            var mail = Session["Mail"].ToString();
            var musteri = db.Müşterilers.FirstOrDefault(y => y.MüşteriMail == mail);
            Favorilerim x = new Favorilerim();
            //var rmv = db.Favorilerims.Find(x.ÜrünId==id && x.MüşteriId==musteri.MüşteriId);
            var rmv = db.Favorilerims.Where(z => z.ÜrünId == id && z.MüşteriId == musteri.MüşteriId).FirstOrDefault();
            db.Favorilerims.Remove(rmv);
            db.SaveChanges();
            return RedirectToAction("FavoriListe", "KullanıcıFavori");


        }
    }
}