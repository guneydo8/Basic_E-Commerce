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
    public class ÜrünlerController : Controller
    {

        // GET: Ürünler
        Context db = new Context();
        public ActionResult Liste()
        {
            var liste = db.Ürünlers.Where(x => x.Durum == true).ToList();
            return View(liste);
        }

        public ActionResult Ekle()
        {
            List<SelectListItem> kategori = (from x in db.Kategoris
                                             select
                       new SelectListItem
                       {
                           Text = x.KategoriAd,
                           Value = x.KategoriId.ToString()
                       }).ToList();

            ViewBag.ktg = kategori;
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Ürünler x,HttpPostedFileBase ÜrünGörsel)
        {
            if (ÜrünGörsel != null)
            {
                string dosyaadi = Path.GetFileName(ÜrünGörsel.FileName);
                string yol = "/Image/" + dosyaadi;
                ÜrünGörsel.SaveAs(Server.MapPath(yol));
                x.ÜrünGörsel = yol;
            }
            x.Durum = true;
            db.Ürünlers.Add(x);
            db.SaveChanges();
            return RedirectToAction("Liste");

        }

        public ActionResult Sil(int id)
        {
            var bul = db.Ürünlers.Find(id);
            bul.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Liste");

        }

        public ActionResult Güncelle(int id)
        {
            var bul = db.Ürünlers.Find(id);
            List<SelectListItem> kategori = (from x in db.Kategoris
                                             select
                       new SelectListItem
                       {
                           Text = x.KategoriAd,
                           Value = x.KategoriId.ToString()
                       }).ToList();

            ViewBag.ktg = kategori;

            return View(bul);
        }

        [HttpPost]
        public ActionResult Güncelle(Ürünler x,HttpPostedFileBase ÜrünGörsel)
        {
            
            var guncelle = db.Ürünlers.Find(x.ÜrünId);
            guncelle.AlışFiyat = x.AlışFiyat;
            guncelle.Marka = x.Marka;
            guncelle.SatışFiyat = x.SatışFiyat;
            guncelle.Stok = x.Stok;
            guncelle.ÜrünAd = x.ÜrünAd;
            guncelle.KategoriId = x.KategoriId;
            guncelle.ÜrünBilgi = x.ÜrünBilgi;

            if (ModelState.IsValid)
            {

                if (ÜrünGörsel != null)
                {
                    string dosyaadi = Path.GetFileName(ÜrünGörsel.FileName);
                    // string uzantı = Path.GetExtension(PizzaImage.FileName);
                    string yol = "/Image/" + dosyaadi;
                    ÜrünGörsel.SaveAs(Server.MapPath(yol));
                    guncelle.ÜrünGörsel = yol;
                }
            }

            db.SaveChanges();
            return RedirectToAction("Liste");
        }

        public ActionResult ÜrünRapor()
        {
            
            var rapor = db.Ürünlers.ToList();
            return View(rapor);
        }

       

        public ActionResult urundetay(int id)
        {
            Class1 bgl = new Class1();
            bgl.ürn = db.Ürünlers.Where(x => x.ÜrünId == id).ToList();
          
           
            return View(bgl);
        }


        public ActionResult ÜrünSatış(int id)
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

            var ürün = db.Ürünlers.Where(x => x.ÜrünId == id).Select(y => y.ÜrünAd).FirstOrDefault();
            ViewBag.ürn = ürün;

            var fiyat= db.Ürünlers.Where(x => x.ÜrünId == id).Select(y => y.SatışFiyat).FirstOrDefault();
            ViewBag.fyt = fiyat;
            var urunıd = db.Ürünlers.Where(x => x.ÜrünId == id).Select(y => y.ÜrünId).FirstOrDefault();
            ViewBag.urnıd = urunıd;

            return View();
        }

        [HttpPost]
        public ActionResult ÜrünSatış(Satışlar x)
        {
            
            x.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
          
            db.Satışlars.Add(x);
            db.SaveChanges();



            return RedirectToAction("Liste", "Satışlar");
        }

        public ActionResult YeniKargo(int id)
        {

        
            Random rnd = new Random();
            string[] karakterler = { "A", "B", "C", "D", "E", "F" };
            int k1, k2, k3;
            k1 = rnd.Next(0, 6);
            k2 = rnd.Next(0, 6);
            k3 = rnd.Next(0, 6);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 100);
            s3 = rnd.Next(10, 100);
            string kod = s1.ToString() + karakterler[k1] + s2.ToString() + karakterler[k2] + s3.ToString() + karakterler[k3];

            Kargo x = new Kargo();
            x.SatışId = id;
            x.TakipKodu = kod;
            x.Tarih = DateTime.Parse(DateTime.Now.ToString());
            db.Kargos.Add(x);
            db.SaveChanges();


            return RedirectToAction("Index", "Kargo");


        }
       


    }
}