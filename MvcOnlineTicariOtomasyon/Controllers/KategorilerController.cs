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
    public class KategorilerController : Controller
    {

        // GET: Kategoriler

        Context x = new Context();
        public ActionResult Liste()
        {
            var liste = x.Kategoris.ToList();
            return View(liste);
        }

        public ActionResult Ekle()
        {
            return View();
            

        }

        [HttpPost]
        public ActionResult Ekle(Kategori y,HttpPostedFileBase KategoriGörsel)
        {
            if (KategoriGörsel != null)
            {
                string dosyaadi = Path.GetFileName(KategoriGörsel.FileName);
                string yol = "/Image/" + dosyaadi;
                KategoriGörsel.SaveAs(Server.MapPath(yol));
                y.KategoriGörsel = yol;
            }
            x.Kategoris.Add(y);
            x.SaveChanges();
            return RedirectToAction("Liste");

        }
        public ActionResult Sil(int id)
        {
            var bul=x.Kategoris.Find(id);
            x.Kategoris.Remove(bul);
            x.SaveChanges();
            return RedirectToAction("Liste");
        }

        public ActionResult Güncelle(int id)
        {
            var bul = x.Kategoris.Find(id);
            return View("Güncelle",bul);
        }
        [HttpPost]
        public ActionResult Güncelle(Kategori y,HttpPostedFileBase KategoriGörsel)
        {
            var güncelle = x.Kategoris.Find(y.KategoriId);
            güncelle.KategoriAd = y.KategoriAd;

            if (ModelState.IsValid)
            {

                if (KategoriGörsel != null)
                {
                    string dosyaadi = Path.GetFileName(KategoriGörsel.FileName);
                    // string uzantı = Path.GetExtension(PizzaImage.FileName);
                    string yol = "/Image/" + dosyaadi;
                    KategoriGörsel.SaveAs(Server.MapPath(yol));
                    güncelle.KategoriGörsel = yol;
                }
            }


            x.SaveChanges();
            return RedirectToAction("Liste");
        }

        public ActionResult Detay(int id)
        {
            var bul = x.Ürünlers.Where(y => y.KategoriId == id).ToList();
            var bul2 = x.Kategoris.Where(y => y.KategoriId == id).Select(z=>z.KategoriAd).FirstOrDefault();
            ViewBag.d1 = bul2;
            return View(bul);
        }

    }
}