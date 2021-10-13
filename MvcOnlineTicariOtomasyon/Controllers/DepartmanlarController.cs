using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class DepartmanlarController : Controller
    {
        // GET: Departmanlar
        Context db = new Context();
        public ActionResult Liste()
        {
            var liste = db.Departmanlars.Where(x=>x.Durum==true).ToList();
            return View(liste);
        }

        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Departmanlar x)
        {
            x.Durum = true;
            db.Departmanlars.Add(x);
           
            db.SaveChanges();

            return RedirectToAction("Liste");
        }
        public ActionResult Güncelle(int id)
        {
            var bul=db.Departmanlars.Find(id);
            return View(bul);

        }

        [HttpPost]
        public ActionResult Güncelle(Departmanlar x)
        {
            var t = db.Departmanlars.Find(x.DepartmanId);
            t.DepartmanAd = x.DepartmanAd;
            db.SaveChanges();
            return RedirectToAction("Liste");
        }

        public ActionResult Sil(int id)
        {
            var bul = db.Departmanlars.Find(id);
            bul.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Liste");
        }

        public ActionResult Detay(int id)
        {
            var bul = db.Personellers.Where(x => x.Departmanlar.DepartmanId == id).ToList();
            var departmanbul = db.Departmanlars.Where(x => x.DepartmanId == id).Select(y => y.DepartmanAd).FirstOrDefault();
           
            ViewBag.d1 = departmanbul;
            return View(bul);
        }
        public ActionResult PersonelSatış(int id)
        {
            var prs = db.Satışlars.Where(x => x.PersonelId == id).ToList();
            var deger = db.Personellers.Where(x => x.PersonelId == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.d = deger;
            return View(prs);
        }

    }
}