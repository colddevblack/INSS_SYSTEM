using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INSSWEBMVC.ConnectContext;
using INSSWEBMVC.Entity;

namespace INSSWEBMVC.Controllers
{
    public class HomeController : Controller
    {
        private DataContext db;

        public HomeController()
        {
            db = new DataContext();
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ConsultaInss()

        {
            
            
            return View(db.Inssdb.ToList());
        }

        [HttpGet]
        public ActionResult CadastroInss()
        {
            return View();
        }
        //cadastro manual de anos Inss
        [HttpPost]
        public ActionResult CadastroInss(InssModel inss)
        {
           
            inss.dataCriacao = DateTime.Now;
            db.Inssdb.Add(inss);
           
            db.SaveChanges();
            return RedirectToAction("ConsultaInss");
        }

        [HttpGet]
        public ActionResult EditarInss(int id)
        {
            var model = db.Inssdb.Find(id);


            return View(model);
        }
        
       public ActionResult DeletarInss(int Id)
        {
            
            var obj = db.Inssdb.Find(Id);
            db.Inssdb.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("ConsultaInss");
        }


        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}