using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KullanıcıGüncelleController : Controller
    {
        Context db = new Context();
        // GET: KullanıcıGüncelle
        public ActionResult Index(int id)
        {
            
            var find = db.Müşterilers.Find(id);
            return View(find);
        }

        [HttpPost]
        public ActionResult Index(Müşteriler x, HttpPostedFileBase MüşteriFotograf)
        {
            var güncelle = db.Müşterilers.Find(x.MüşteriId);
            güncelle.MüşteriAd = x.MüşteriAd;
            güncelle.MüşteriMail = x.MüşteriMail;
            güncelle.MüşteriSoyad = x.MüşteriSoyad;
            güncelle.MüşteriŞehir = x.MüşteriŞehir;
            güncelle.MüşteriŞifre = x.MüşteriŞifre;
            

            if (ModelState.IsValid)
            {

                if (MüşteriFotograf != null)
                {
                    string dosyaadi = Path.GetFileName(MüşteriFotograf.FileName);
                    // string uzantı = Path.GetExtension(PizzaImage.FileName);
                    string yol = "/Image/" + dosyaadi;
                    MüşteriFotograf.SaveAs(Server.MapPath(yol));
                    güncelle.MüşteriFotograf = yol;
                }
            }


            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}