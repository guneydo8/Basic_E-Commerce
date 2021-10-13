using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;


namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KullanıcıLoginController : Controller
    {
        // GET: KullanıcıLogin
        Context db = new Context();
        public ActionResult Login(Müşteriler x)
        {
            var giriş = db.Müşterilers.FirstOrDefault(y => y.MüşteriMail == x.MüşteriMail && y.MüşteriŞifre == x.MüşteriŞifre);

            if (giriş != null)
            {
                FormsAuthentication.SetAuthCookie(giriş.MüşteriMail, false);
                Session["Mail"] = giriş.MüşteriMail;
                return RedirectToAction("Index", "KullanıcıAnaSayfa");
            }
            else
            {
                return View();

            }


        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Müşteriler x)
        {
            db.Müşterilers.Add(x);
            x.Durum = true;
            db.SaveChanges();
            return RedirectToAction("Login");

        }

        public ActionResult Cıkış()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "KullanıcıLogin");
        }

        public PartialViewResult kullanıcı()
        {
            var mail = Session["Mail"].ToString();
            var kullanıcı2 = db.Müşterilers.FirstOrDefault(x => x.MüşteriMail == mail);
            ViewBag.musteriıd = kullanıcı2.MüşteriId;


            var kullanıcı = db.Müşterilers.Where(x => x.MüşteriMail == mail).Select(y => y.MüşteriAd + " " + y.MüşteriSoyad).FirstOrDefault();
            ViewBag.d2 = kullanıcı;
            if (mail == null)
            {
                ViewBag.d1 = "Giriş Yap";
            }
            if (mail != null)
            {
                ViewBag.d1 = "Çıkış Yap";
            }

            return PartialView();

        }

        public PartialViewResult kullanıcı2()
        {
            var mail = Session["Mail"].ToString();
            var favori = db.Favorilerims.Where(x => x.Müşteriler.MüşteriMail == mail).Count();
            var sepet = db.Sepetims.Where(x => x.Müşteriler.MüşteriMail == mail).Count();
            ViewBag.f = favori;
            ViewBag.s = sepet;
            return PartialView();
        }

    }
}