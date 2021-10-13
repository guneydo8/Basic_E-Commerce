using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KullanıcıKargoController : Controller
    {
        // GET: KullanıcıKargo
        Context db = new Context();
        public ActionResult Index(string takipno)
        {
            var mail = Session["Mail"].ToString();
            //var list= db.Kargos.Where(x => x.TakipKodu.Contains(takipno) && x.Satışlar.Müşteriler.MüşteriMail==mail).ToList();


            var list = db.Kargos.Where(x => x.Satışlar.Müşteriler.MüşteriMail == mail).ToList();


            return View(list);
        }

        public ActionResult Index2(int id)
        {
            var list = db.KargoTakips.Where(x => x.KargoId == id).ToList();
            return View(list);
        }
    }
}