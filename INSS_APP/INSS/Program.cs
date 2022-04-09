using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INSS;

namespace INSS
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal salario = 0;
            decimal inss = 0;

            decimal salarioLiquido = 0;
            decimal teto = 0;
            DateTime data = DateTime.Now;
            Console.WriteLine("Versão simples versão console app - NET FRAMEWORK ");
            Console.WriteLine("Exemplo Calculo de 2012 ");

            Console.WriteLine("Qual o seu Salario? ");
            salario = Convert.ToDecimal(Console.ReadLine());

            var excut = new RegraInss();

            ICalculadorInss calculadorInss = excut;
            var descontoInss = calculadorInss.CalcularDesconto(data, salario);
            Console.WriteLine("Hoje data " + data + "Inss de 2012 calculado");
            Console.WriteLine("Seu Salario é de R$: " + salario);
            Console.WriteLine("Desconto R$ " + descontoInss + " de INSS");
            
            Console.ReadLine();
            }
        }

}