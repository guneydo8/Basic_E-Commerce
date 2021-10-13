using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DuyuruController : Controller
    {
        // GET: Duyuru
        Context db = new Context();
        public ActionResult Index()
        {
            var list = db.Duyurus.ToList();
            return View(list);
        }
    }
}