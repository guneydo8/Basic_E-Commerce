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
    public class PersonellerController : Controller
    {
        Context db = new Context();
        // GET: Personeller
        public ActionResult Liste()
        {
            var liste = db.Personellers.Where(x=>x.Durum==true).ToList();


            return View(liste);
        }

        [Authorize(Roles ="A")]
        public ActionResult Ekle()
        {
            List<SelectListItem> dpt = (from x in db.Departmanlars
                                        select new SelectListItem
                                        {
                                            Text = x.DepartmanAd,
                                            Value = x.DepartmanId.ToString()
                                        }).ToList();

            ViewBag.d1 = dpt;

            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Personeller x,HttpPostedFileBase PersonelFotograf)
        {
            if (PersonelFotograf != null)
            {
                string dosyaadi = Path.GetFileName(PersonelFotograf.FileName);
                string yol = "/Image/" + dosyaadi;
                PersonelFotograf.SaveAs(Server.MapPath(yol));
                x.PersonelFotograf = yol;
            }
            x.Durum = true;
            db.Personellers.Add(x);
            
            db.SaveChanges();
            return RedirectToAction("Liste");
        }
        public ActionResult Sil(int id)
        {
            var bul = db.Personellers.Find(id);
            bul.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Liste");
        }

        public ActionResult Güncelle(int id)
        {
            var bul = db.Personellers.Find(id);
            List<SelectListItem> dpt = (from x in db.Departmanlars
                                        select new SelectListItem
                                        {
                                            Text = x.DepartmanAd,
                                            Value = x.DepartmanId.ToString()
                                        }).ToList();

            ViewBag.d1 = dpt;
            return View(bul);
        }

        [HttpPost]
        public ActionResult Güncelle(Personeller x,HttpPostedFileBase PersonelFotograf)
        {
            var gnc = db.Personellers.Find(x.PersonelId);
            gnc.PersonelAd = x.PersonelAd;

            gnc.PersonelSoyad = x.PersonelSoyad;
            gnc.DepartmanId = x.DepartmanId;

            if (ModelState.IsValid)
            {

                if (PersonelFotograf != null)
                {
                    string dosyaadi = Path.GetFileName(PersonelFotograf.FileName);
                    // string uzantı = Path.GetExtension(PizzaImage.FileName);
                    string yol = "/Image/" + dosyaadi;
                    PersonelFotograf.SaveAs(Server.MapPath(yol));
                    gnc.PersonelFotograf = yol;
                }
            }

            db.SaveChanges();
            return RedirectToAction("Liste");
        }

        public ActionResult PersonelRapor()
        {
            var rapor = db.Personellers.ToList();
            return View(rapor);
        }

        public ActionResult PersonelCard()
        {
            var list = db.Personellers.ToList();
           
            return View(list);
        }
    }
}