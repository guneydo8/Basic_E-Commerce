using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class İstatistiklerController : Controller
    {
        
        // GET: İstatistikler
        Context db = new Context();
        public ActionResult Liste()
        {

            var toplammusteri = db.Müşterilers.Where(x => x.Durum == true).Count();
            var toplamürün = db.Ürünlers.Where(x => x.Durum == true).Count();
            var toplampersonel = db.Personellers.Where(x => x.Durum == true).Count();
            var kasatoplamı = db.Satışlars.Sum(x => x.ToplamFiyat);
            var kategorisayısı = db.Kategoris.Count();
            var toplamstok = db.Ürünlers.Where(x => x.Durum == true).Sum(x => x.Stok);
            var kritikseviye = db.Ürünlers.Count(x => x.Stok <= 20);
            var maxfiyaturun = (from x in db.Ürünlers orderby x.SatışFiyat descending select x.ÜrünAd).FirstOrDefault();

            var minfiyaturun = (from x in db.Ürünlers orderby x.SatışFiyat select x.ÜrünAd).FirstOrDefault();

            var toplamsatış = db.Satışlars.Count();

            DateTime bugun = DateTime.Today;

            var deger16 = db.Satışlars.Count(x => x.Tarih == bugun).ToString();
            var deger5 = db.Mesajlars.Count();
            var deger6 = db.Yorumlars.Count();
            var deger11 = db.Duyurus.Count();
            var deger13 = db.Sepetims.Count();
            var deger14 = db.Favorilerims.Count();

            ViewBag.d1 = toplammusteri;
            ViewBag.d2 = toplamürün;
            ViewBag.d3 = toplampersonel;
            ViewBag.d4 = kasatoplamı;
            ViewBag.d7 = kategorisayısı;
            ViewBag.d8 = toplamstok;
            ViewBag.d15 = kritikseviye;
            ViewBag.d9 = maxfiyaturun;
            ViewBag.d10 = minfiyaturun;
            ViewBag.d12 = toplamsatış;
            ViewBag.d16 = deger16;
            ViewBag.d5 = deger5;
            ViewBag.d6 = deger6;
            ViewBag.d11 = deger11;
            ViewBag.d13 = deger13;
            ViewBag.d14 = deger14;

            return View();
        }
    }
}