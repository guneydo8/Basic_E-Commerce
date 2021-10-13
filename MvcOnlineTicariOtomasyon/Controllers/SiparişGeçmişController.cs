using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SiparişGeçmişController : Controller
    {
        // GET: SiparişGeçmiş
        Context db = new Context();

        public ActionResult Index()
        {
            var mail = Session["Mail"].ToString();
            var musteri = db.Müşterilers.FirstOrDefault(x => x.MüşteriMail == mail);
            var list = db.Satışlars.Where(x => x.MüşteriId == musteri.MüşteriId).OrderByDescending(y=>y.SatışId).ToList();
            return View(list);
        }
    }
}