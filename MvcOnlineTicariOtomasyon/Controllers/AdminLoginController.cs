using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        Context db = new Context();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin x)
        {
            var giris = db.Admins.FirstOrDefault(t => t.KullanıcıAd == x.KullanıcıAd && t.Şifre == x.Şifre);

            if (giris != null)
            {
                FormsAuthentication.SetAuthCookie(giris.KullanıcıAd, false);
                Session["Admin"] = giris.KullanıcıAd;
                return RedirectToAction("Index", "AnaSayfa");
            }
            else
            {
                return View();
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
           
            return RedirectToAction("Login", "AdminLogin");
        }

        public PartialViewResult Admin()
        {
            var admin = Session["Admin"].ToString();
            ViewBag.a = admin;
            return PartialView();
        }

        public PartialViewResult Bildirim()
        {
            Class1 bgl = new Class1();
            bgl.yrm = db.Yorumlars.OrderByDescending(x => x.YorumId).ToList().Take(5);
            var mesaj = db.Mesajlars.Count();
            var yorum = db.Yorumlars.Count();
            var duyuru = db.Duyurus.Count();

            ViewBag.d1 = mesaj;
            ViewBag.d2 = yorum;
            ViewBag.d3 = duyuru;

            var toplam = mesaj + yorum + duyuru;
            ViewBag.d4 = toplam;
            return PartialView(bgl);
        }
    }
}