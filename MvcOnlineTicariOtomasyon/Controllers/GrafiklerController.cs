using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class GrafiklerController : Controller
    {
        // GET: Grafikler

        Context db = new Context();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VisualizeDepartmanResult()
        {
            return Json(DepartmanListesi(), JsonRequestBehavior.AllowGet);
        }

        public List<personelgrup> DepartmanListesi()
        {
            List<personelgrup> snf = new List<personelgrup>();
            snf = (from x in db.Personellers
                   group x by x.Departmanlar.DepartmanAd into y
                   select new personelgrup
                   {
                       Depatman = y.Key,
                       Sayi = y.Count()
                   }).ToList();
            return snf;
        }
        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult VisualizeUrünResult()
        {
            return Json(UrünListesi(), JsonRequestBehavior.AllowGet);
        }
        public List<ÜrünStok> UrünListesi()
        {

            List<ÜrünStok> snf = new List<ÜrünStok>();
            {
                snf = db.Ürünlers.Select(x => new ÜrünStok
                {
                    Ürün = x.ÜrünAd,
                    Stok = x.Stok
                }).ToList();
            }

            return snf;
        }

        public ActionResult Index3()
        {
            return View();
        }

        public ActionResult VisialuzePersonelSatışResult()
        {
            return Json(PersonelListesi(), JsonRequestBehavior.AllowGet);
        }

        public List<personelsatış> PersonelListesi()
        {
            List<personelsatış> snf = new List<personelsatış>();
            snf = (from x in db.Satışlars
                   group x by x.Personeller.PersonelAd + " " + x.Personeller.PersonelSoyad into y
                   select new personelsatış
                   {
                       Personel = y.Key,
                       Sayi = y.Count()
                   }).ToList();
            return snf;
        }

        public ActionResult Index4()
        {
            return View();
        }

        public ActionResult VisualizeÜrünSatışResult()
        {
            return Json(ÜrünSatış(), JsonRequestBehavior.AllowGet);
        }

        public List<ÜrünGrup> ÜrünSatış()
        {
            List<ÜrünGrup> snf = new List<ÜrünGrup>();
            snf=(from x in db.Satışlars
                              group x by x.Ürünler.ÜrünAd
                          into y
                              select new ÜrünGrup
                              {
                                  Ürün = y.Key,
                                  Sayi = y.Count()
                              }).ToList();

            return snf;
        }
    }
}