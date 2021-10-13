using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class MüşterilerController : Controller
    {
        Context db = new Context();
        // GET: Müşteriler
        public ActionResult Liste()
        {
            var liste = db.Müşterilers.Where(x=>x.Durum==true).ToList();
            return View(liste);
        }
        public ActionResult Ekle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Ekle(Müşteriler x,HttpPostedFileBase MüşteriFotograf)
        {

            if (MüşteriFotograf != null)
            {
                string dosyaadi = Path.GetFileName(MüşteriFotograf.FileName);
                string yol = "/Image/" + dosyaadi;
                MüşteriFotograf.SaveAs(Server.MapPath(yol));
                x.MüşteriFotograf = yol;
            }
            x.Durum = true;
            db.Müşterilers.Add(x);
          
            db.SaveChanges();
            return RedirectToAction("Liste");
        }
        public ActionResult Sil(int id)
        {
            var rmv = db.Müşterilers.Find(id);
            rmv.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Liste");
        }
        public ActionResult Güncelle(int id)
        {
            var gnc = db.Müşterilers.Find(id);
            return View(gnc);
        }
        [HttpPost]
        public ActionResult Güncelle(Müşteriler x,HttpPostedFileBase MüşteriFotograf)
        {
            var gnc = db.Müşterilers.Find(x.MüşteriId);
            gnc.MüşteriMail = x.MüşteriMail;
            gnc.MüşteriAd = x.MüşteriAd;
            gnc.MüşteriSoyad = x.MüşteriSoyad;
            gnc.MüşteriŞehir = x.MüşteriŞehir;

            if (ModelState.IsValid)
            {

                if (MüşteriFotograf != null)
                {
                    string dosyaadi = Path.GetFileName(MüşteriFotograf.FileName);
                    // string uzantı = Path.GetExtension(PizzaImage.FileName);
                    string yol = "/Image/" + dosyaadi;
                    MüşteriFotograf.SaveAs(Server.MapPath(yol));
                    gnc.MüşteriFotograf = yol;
                }
            }
            db.SaveChanges();
            return RedirectToAction("Liste");
        }

        public ActionResult Detay(int id)
        {
            var bul = db.Satışlars.Where(x => x.MüşteriId == id).ToList();
            var deger = db.Müşterilers.Where(x => x.MüşteriId == id).Select(y => y.MüşteriAd + " " + y.MüşteriSoyad).FirstOrDefault();
            ViewBag.d = deger;
            ViewBag.d1 = bul;
            return View(bul);
        }

        public ActionResult MüşteriRapor()
        {
            var rapor = db.Müşterilers.ToList();
            return View(rapor);
        }
    }
}