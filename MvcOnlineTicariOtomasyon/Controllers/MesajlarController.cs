using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class MesajlarController : Controller
    {
        // GET: Mesajlar
        Context db = new Context();
        public ActionResult InBox()
        {
            var mail = Session["Mail"].ToString();
            var list = db.Mesajlars.Where(x => x.Alıcı == mail).OrderByDescending(c=>c.Tarih).ToList();
          



            return View(list);
        }


        public ActionResult OutBox()
        {
            var mail = Session["Mail"].ToString();
            var list = db.Mesajlars.Where(x => x.Gönderen == mail).OrderByDescending(c => c.Tarih).ToList();




            return View(list);
        }
        public ActionResult Read(int id)
        {
            var mesaj = db.Mesajlars.Where(x => x.MesajId == id).ToList();
            return View(mesaj);
        }

        public PartialViewResult Menu()
        {
            var mail = Session["Mail"].ToString();
            var gelensayi = db.Mesajlars.Where(x => x.Alıcı == mail).Count();
            var gidensayi = db.Mesajlars.Where(x => x.Gönderen == mail).Count();
            ViewBag.d1 = gelensayi;
            ViewBag.d2 = gidensayi;
            return PartialView();
        }

        public ActionResult Compose()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Compose(Mesajlar x)
        {
            var mail = Session["Mail"].ToString();
            x.Gönderen = mail;
            x.Tarih = DateTime.Parse(DateTime.Now.ToString());
            db.Mesajlars.Add(x);
            db.SaveChanges();

            return RedirectToAction("Inbox");
        }
    }
}