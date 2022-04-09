using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INSSWEBMVC.ConnectContext;
using INSSWEBMVC.Entity;
//using System.Management.Automation.PowerShell;

namespace INSSWEBMVC.Controllers
{
    public class DataBaseIncialController : Controller
    {
        //efetuar as migrations antes de executar Migrations Entity
        private DataContext db;

        public DataBaseIncialController() {
            db = new DataContext();
        }



        
        public ActionResult CriarBanco()
        {
            decimal teto = 500;
            var cadastro1 = new InssModel()
            {
                id = 1,
                ano = "2012",
                LimiteSalario = 1000,
                dataCriacao = DateTime.Now,
                porcentagem = 7
            };

            var cadastro2 = new InssModel()
            {
                id = 2,
                ano = "2012",
                LimiteSalario = 1500,
                dataCriacao = DateTime.Now,
                porcentagem = 8
            };

            var cadastro3 = new InssModel()
            {
                id = 3,
                ano = "2012",
                LimiteSalario = 3000,
                dataCriacao = DateTime.Now,
                porcentagem = 9
            };


            var cadastro4 = new InssModel()
            {
                id = 4,
                ano = "2012",
                LimiteSalario = 4000,
                dataCriacao = DateTime.Now,
                porcentagem = 11
            };

            var cadastro5 = new InssModel()
            {
                id = 5,
                ano = "2012",
                LimiteSalario = 4001,
                dataCriacao = DateTime.Now,
                porcentagem = teto
            };
            var obj = db.Inssdb.Add(cadastro1);
            var obj2 = db.Inssdb.Add(cadastro2);
            var obj3 = db.Inssdb.Add(cadastro3);
            var obj4 = db.Inssdb.Add(cadastro4);
            var obj5 = db.Inssdb.Add(cadastro5);
           

            db.SaveChanges();
            return RedirectToAction("ConsultaInss");
        }

        public ActionResult ConsultaInss()

        {


            return View(db.Inssdb.ToList());
        }
    }
}