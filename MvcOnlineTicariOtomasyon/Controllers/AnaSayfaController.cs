using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;


namespace MvcOnlineTicariOtomasyon.Controllers
{
     [Authorize]
    public class AnaSayfaController : Controller
    {
        // GET: AnaSayfa
        Context db = new Context();
        Class1 bgl = new Class1();



        public ActionResult Index()
        {
            var şehir = (from x in db.Müşterilers select x.MüşteriŞehir).Distinct().Count();
            ViewBag.d1 = şehir;
            var müşteri = db.Müşterilers.Count();
            ViewBag.d2 = müşteri;
            var ürün = db.Ürünlers.Count();
            ViewBag.d3 = ürün;
            var personel = db.Personellers.Count();
            ViewBag.d4 = personel;
         
            bgl.todo = db.TodoLists.ToList();
            return View(bgl);

        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(TodoList x)
        {
            db.TodoLists.Add(x);
            x.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var rmv = db.TodoLists.Find(id);
            db.TodoLists.Remove(rmv);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var find = db.TodoLists.Find(id);
            return View(find);
        }

        [HttpPost]
        public ActionResult Edit(TodoList x)
        {
            var edt = db.TodoLists.Find(x.Id);
            edt.İçerik = x.İçerik;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}