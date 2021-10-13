using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class GaleriController : Controller
    {
        // GET: Galeri
        Context db = new Context();
       
        public ActionResult Liste()
        {
            var liste = db.Ürünlers.ToList();
            return View(liste);
        }
    }
}