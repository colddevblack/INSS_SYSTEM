using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INSSWEBMVC.ConnectContext;
using INSSWEBMVC.Entity;
using INSSWEBMVC.Interface;


namespace INSSWEBMVC.Controllers
{
    public class CalculoController : Controller
    {
        private DataContext db;

        public CalculoController()
        {
            db = new DataContext();
        }

       

        public ActionResult ConsultaCalculoInss()

        {
            
            
            return View(db.calculodb.ToList());
        }

        [HttpGet]
        public ActionResult CalculoInss()
        {
           

            return View();
        }

        [HttpPost]
        public ActionResult CalculoInss(CalculoModel calcul)
        {
            //Caclcula Inss necessario incluir informações de anos de inss no banco
            calcul.dataCriacaoCalculo = DateTime.Now;
            var excut = new RegraInss();

            ICalculadorInss calculadorInss = excut;
            var calculaDesconto = calculadorInss.CalcularDesconto(calcul.dataCriacaoCalculo, calcul.Salario);
            calcul.descontoInss = calculaDesconto;
            calcul.SalarioLiquido = calcul.Salario - calcul.descontoInss;



            db.calculodb.Add(calcul);
            db.SaveChanges();
            return RedirectToAction("ConsultaCalculoInss");
        }
        [HttpGet]
        public ActionResult CalculoInssPorAno()
        {
            ViewBag.inssid = new SelectList(db.Inssdb.ToList(), "id", "ano", "Limite Salario");

            return View();
        }

        [HttpPost]
        public ActionResult CalculoInssPorAno(CalculoModel calcul)
        {
            //Caclcula Inss necessario incluir informações de anos de inss no banco
            calcul.dataCriacaoCalculo = DateTime.Now;
            var Buscaporcentagem = db.Inssdb.Find(calcul.inssid);
            var percent = Buscaporcentagem.porcentagem;

            calcul.descontoInss = calcul.Salario * percent / 100;
            calcul.SalarioLiquido = calcul.Salario - calcul.descontoInss;

            db.calculodb.Add(calcul);
            db.SaveChanges();
            return RedirectToAction("ConsultaCalculoInss");
        }


    }
}