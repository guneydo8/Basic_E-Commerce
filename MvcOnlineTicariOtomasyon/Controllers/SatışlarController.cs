using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class SatışlarController : Controller
    {
        // GET: Satışlar
        Context db = new Context();
        public ActionResult Liste()
        {
            var liste = db.Satışlars.ToList();
            return View(liste);
        }

        public ActionResult Ekle()
        {
            
            List<SelectListItem> müsteri = (from x in db.Müşterilers
                                            select new SelectListItem
                                            {
                                                Text = x.MüşteriAd + " " + x.MüşteriSoyad,
                                                Value = x.MüşteriId.ToString()
                                            }).ToList();

            ViewBag.mst = müsteri;


            List<SelectListItem> personel = (from x in db.Personellers
                                            select new SelectListItem
                                            {
                                                Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                Value = x.PersonelId.ToString()
                                            }).ToList();

            ViewBag.prs = personel;


            List<SelectListItem> ürün = (from x in db.Ürünlers
                                            select new SelectListItem
                                            {
                                                Text = x.ÜrünAd,
                                                Value = x.ÜrünId.ToString()
                                            }).ToList();

            ViewBag.ürn = ürün;




            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Satışlar x)
        {
            db.Satışlars.Add(x);
            x.Tarih =Convert.ToDateTime(DateTime.Now.ToString());
            
            db.SaveChanges();
            return RedirectToAction("Liste");
        }

        public ActionResult Satışİptal(int id)
        {
            var bul = db.Satışlars.Find(id);
            db.Satışlars.Remove(bul);
            db.SaveChanges();
            return RedirectToAction("Liste");
        }

        public ActionResult SatışRapor()
        {
            var rapor = db.Satışlars.ToList();
            return View(rapor);
        }

    }
}