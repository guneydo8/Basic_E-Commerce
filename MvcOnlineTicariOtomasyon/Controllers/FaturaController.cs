using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;


namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class FaturaController : Controller
    {
        // GET: Fatura

        Context db = new Context();
        public ActionResult Liste()
        {
            var liste = db.Faturalars.ToList();
            return View(liste);
        }

        public ActionResult Ekle()
        {
            List<SelectListItem> customer = (from x in db.Müşterilers
                                             select new SelectListItem
                                             {
                                                 Text = x.MüşteriAd + " " + x.MüşteriSoyad,
                                                 Value = x.MüşteriId.ToString()
                                             }).ToList();
            ViewBag.mst = customer;
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Faturalar x)
        {
            db.Faturalars.Add(x);
            x.Tarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());
           
            db.SaveChanges();
            return RedirectToAction("Liste");
        }

        public ActionResult Güncelle(int id)
        {
            List<SelectListItem> customer = (from x in db.Müşterilers
                                             select new SelectListItem
                                             {
                                                 Text = x.MüşteriAd + " " + x.MüşteriSoyad,
                                                 Value = x.MüşteriId.ToString()
                                             }).ToList();
            ViewBag.mst = customer;
            var bul = db.Faturalars.Find(id);
            return View(bul);
        }
        [HttpPost]
        public  ActionResult Güncelle(Faturalar x)
        {
            var gnc = db.Faturalars.Find(x.FaturaId);
            gnc.FaturaSeriNo = x.FaturaSeriNo;
            gnc.FaturaSıraNo = x.FaturaSıraNo;
            gnc.MüşteriId = x.MüşteriId;
           
            gnc.VergiDairesi = x.VergiDairesi;
            db.SaveChanges();
            return RedirectToAction("Liste");
        }

        public ActionResult Detay(int id)
        {
            var bul = db.FaturaKalems.Where(x => x.FaturaId == id).ToList();
            ViewBag.id = id;
            return View(bul);
        }

        public ActionResult FaturaÜrün()
        {
            List<SelectListItem> product = (from x in db.Ürünlers
                                             select new SelectListItem
                                             {
                                                 Text = x.ÜrünAd,
                                                 Value = x.ÜrünId.ToString()
                                             }).ToList();
            ViewBag.ürn = product;

            return View();
        }


        [HttpPost]
        public ActionResult FaturaÜrün(int id,int ÜrünId, decimal BirimFiyat,decimal Tutar,int Miktar)
        {
            FaturaKalem x = new FaturaKalem();
            x.FaturaId = id;
            x.BirimFiyat = BirimFiyat;
            x.Miktar = Miktar;
            x.Tutar = Tutar;
            x.ÜrünId = ÜrünId;
         

            
            db.FaturaKalems.Add(x);
            
            db.SaveChanges();
            
           
            return RedirectToAction("Liste");
        }


        public ActionResult DinamikFatura()
        {
            Class1 bgl = new Class1();
            bgl.ftr = db.Faturalars.ToList();
            bgl.ftrklm = db.FaturaKalems.ToList();
            return View(bgl);
        }
    }
}