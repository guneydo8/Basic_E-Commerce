using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class KargoController : Controller
    {
        // GET: Kargo
        Context db = new Context();
        public ActionResult Index()
        {
            var list = db.Kargos.ToList();
            return View(list);
        }

        public ActionResult Takip(int id)
        {
            var bul = db.Kargos.Find(id);
            
            var list = db.KargoTakips.Where(x => x.KargoId == id).OrderByDescending(y=>y.KargotakipId).ToList();
            ViewBag.d1 = bul.TakipKodu;
            ViewBag.id = bul.KargoId;
           
            return View(list);
        }


        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(int id,string Açıklama)
        {           
            KargoTakip x = new KargoTakip();
            x.Açıklama = Açıklama;
            x.KargoId = id;
            x.Tarih = DateTime.Parse(DateTime.Now.ToString());
            db.KargoTakips.Add(x);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}