using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KullanıcıAnaSayfaController : Controller
    {
        // GET: KullanıcıAnaSayfa
        Context db = new Context();
        Class1 bgl = new Class1();
        public ActionResult Index()
        {


            bgl.ktg = db.Kategoris.ToList().OrderByDescending(x => x.KategoriId).Take(3);
            bgl.ktg2 = db.Kategoris.ToList();
            bgl.ürn = db.Ürünlers.ToList().OrderByDescending(x => x.ÜrünId);
            bgl.ürn2 = db.Ürünlers.Where(y=>y.Stok<=20).ToList().OrderBy(x => x.Stok);
            
            return View(bgl);
        }

        public ActionResult KategoriFiltre(int id)
        {
            bgl.ktg = db.Kategoris.ToList();
            bgl.ürn = db.Ürünlers.Where(y => y.KategoriId == id && y.Durum==true).ToList();
            var deger = db.Ürünlers.Where(y => y.KategoriId == id && y.Durum == true).Count();
            ViewBag.d1 = deger;
            var ktg = db.Kategoris.Where(x => x.KategoriId == id).Select(y => y.KategoriAd).FirstOrDefault();
            ViewBag.d = ktg;

            return View(bgl);
            
        }


    }
}