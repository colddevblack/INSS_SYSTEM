using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INSSWEBMVC.Entity;
using INSSWEBMVC.ConnectContext;
using INSSWEBMVC.Entity;

namespace INSSWEBMVC.Interface
{
   class RegraInss: ICalculadorInss
    {
        decimal descontoInss = 0;
        decimal teto = 500;
        private DataContext db;

        public RegraInss()
        {
            db = new DataContext();
        }

        decimal ICalculadorInss.CalcularDesconto(DateTime data, decimal salario)
        {
            //Exemplo logica inss 2012

            //var result = db.calculodb.Where(c => c.Salario <= 1000).ToList();
            if (salario <= 1000)
            {
                descontoInss = (salario * 7 ) / 100;
               
                return descontoInss;
            }
            else if (salario > 1000 & salario <= 1500)
            {
                descontoInss = (salario * 8) / 100;
               
                return descontoInss;
            }
            else if (salario > 1500 & salario <= 3000)
            {
                descontoInss = (salario * 9) / 100;
               
                return descontoInss;
            }
            else if (salario > 3000 & salario <= 4000)
            {
                descontoInss = (salario * 11) / 100;
                
                return descontoInss;
            }
            else
            {
                descontoInss = teto;
                
                return descontoInss;
            }

            
        }

     

    }
}
