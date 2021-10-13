using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KullanıcıSepetimController : Controller
    {
        // GET: KullanıcıSepetim
        Context db = new Context();
        Class1 bgl = new Class1();

        public ActionResult Index()
        {
            var mail = Session["Mail"].ToString();
            var musteri = db.Müşterilers.FirstOrDefault(x => x.MüşteriMail == mail);
            bgl.spt = db.Sepetims.Where(x => x.MüşteriId == musteri.MüşteriId).ToList();
            //  var toplam = db.Sepetims.Where(y => y.MüşteriId == musteri.MüşteriId).Sum(z => //z.Ürünler.SatışFiyat);
            //ViewBag.t = toplam;
            return View(bgl);
        }


        public ActionResult SepeteEkle(int id)
        {
            var find = db.Ürünlers.Find(id);
            var mail = Session["Mail"].ToString();
            var musteri = db.Müşterilers.FirstOrDefault(y => y.MüşteriMail == mail);
            Sepetim x = new Sepetim();
            x.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            x.MüşteriId = musteri.MüşteriId;
            x.ÜrünId = id;
            x.Adet = 1;
            x.ToplamFiyat = find.SatışFiyat;
            x.BirimFiyat = find.SatışFiyat;
            db.Sepetims.Add(x);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult SepettenÇıkar(int id)
        {
            var find = db.Ürünlers.Find(id);
            var mail = Session["Mail"].ToString();
            var musteri = db.Müşterilers.FirstOrDefault(y => y.MüşteriMail == mail);
            var ürün = db.Sepetims.Where(y => y.MüşteriId == musteri.MüşteriId && y.ÜrünId == id).FirstOrDefault();
            db.Sepetims.Remove(ürün);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult SepetUrunGuncelle(int urunId, int adet)
        {
            var mail = Session["Mail"].ToString();
            var musteri = db.Müşterilers.FirstOrDefault(y => y.MüşteriMail == mail);
            var urun = db.Sepetims.Find(urunId);
            urun.Adet = adet;
            urun.ToplamFiyat = urun.BirimFiyat * adet;
            db.SaveChanges();
            return Json("");
        }
        public ActionResult SatinAl()
        {
            var mail = Session["Mail"].ToString();
            var musteri = db.Müşterilers.FirstOrDefault(y => y.MüşteriMail == mail);
            var urunler = db.Sepetims.Where(x => x.MüşteriId == musteri.MüşteriId).ToList();
            if (urunler == null)
            {
                return RedirectToAction("Index", "KullanıcıAnaSayfa");
            }

            Random rnd2 = new Random();
            string[] karakterler2 = { "A", "B", "C", "D", "E", "F" };
            int k4, k2, k3;
            k4 = rnd2.Next(0, 6);
            k2 = rnd2.Next(0, 6);
            k3 = rnd2.Next(0, 6);
            int s4, s2, s3;
            s4 = rnd2.Next(100, 1000);
            s2 = rnd2.Next(10, 100);
            s3 = rnd2.Next(10, 100);
            string kod = s4.ToString() + karakterler2[k4] + s2.ToString() + karakterler2[k2] + s3.ToString() + karakterler2[k3];

            string sira = s4.ToString();
            string seri = karakterler2[k4];
            Faturalar t = new Faturalar();
            t.FaturaSeriNo = seri;
            t.FaturaSıraNo = sira;
            t.MüşteriId = musteri.MüşteriId;
            t.Tarih = DateTime.Parse(DateTime.Now.ToString());
            t.VergiDairesi = musteri.MüşteriŞehir;
            
            db.Faturalars.Add(t);
           
            db.SaveChanges();

            foreach (var urun in urunler)
            {
               
                
                Satışlar satış = new Satışlar();
                satış.Adet = urun.Adet;
                satış.BirimFiyat = urun.BirimFiyat;
                satış.MüşteriId = musteri.MüşteriId;
                satış.PersonelId = db.Personellers.FirstOrDefault().PersonelId;
                satış.Tarih = DateTime.Now;
                satış.ÜrünId = urun.ÜrünId;
                satış.FaturaId = t.FaturaId;
                ViewBag.id = t.FaturaId;
                
                db.Satışlars.Add(satış);
                db.SaveChanges();
                FaturaKalem f = new FaturaKalem();
                Kargo g = new Kargo();
                g.SatışId = satış.SatışId;
                g.TakipKodu = kod;
                g.Tarih = DateTime.Parse(DateTime.Now.ToString());
                db.Kargos.Add(g);
                KargoTakip p = new KargoTakip();

                p.KargoId = g.KargoId;
                p.Açıklama = "Siparişiniz Bize ulaşmıştır en kısa sürede hazırlanıp kargoya verilecktir.";
                p.Tarih = DateTime.Parse(DateTime.Now.ToString());
                db.KargoTakips.Add(p);
                f.BirimFiyat = urun.BirimFiyat;
                f.Miktar = urun.Adet;
                f.Tutar = urun.Adet * urun.BirimFiyat;
              
                f.ÜrünId = urun.ÜrünId;
                f.FaturaId = t.FaturaId;
                db.FaturaKalems.Add(f);
                
                db.Sepetims.Remove(urun);
            }

            db.SaveChanges();

            return RedirectToAction("Index", "KullanıcıAnaSayfa");
        }



       

        public ActionResult KullanıcıFatura()
        {
            Class1 bgl = new Class1();
            var mail = Session["Mail"].ToString();
            var musteri = db.Müşterilers.FirstOrDefault(y => y.MüşteriMail == mail);
            var fatura = db.Satışlars.Where(x => x.MüşteriId == musteri.MüşteriId).OrderByDescending(t => t.SatışId).Select(c => c.FaturaId).FirstOrDefault();
            bgl.ftr = db.Faturalars.Where(x => x.FaturaId == fatura).ToList();
            bgl.ftrklm = db.FaturaKalems.Where(x => x.FaturaId == fatura).ToList();
            var tutar = db.FaturaKalems.Where(x => x.FaturaId == fatura).Sum(x => x.Tutar);
            ViewBag.t = tutar;
           
            return View(bgl);
        }


    }
}