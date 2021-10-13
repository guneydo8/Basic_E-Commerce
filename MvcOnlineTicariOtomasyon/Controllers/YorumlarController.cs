using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class YorumlarController : Controller
    {
        // GET: Yorumlar
        Context db = new Context();
        public ActionResult Liste()
        {
            var list = db.Yorumlars.ToList();
            return View(list);
        }
    }
}