using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace INSSWEBMVC.Entity
{
    public class CalculoModel
    {
        [Key]
        public int id { get; set; }
        public string NomeEmpregado { get; set; }
        public decimal Salario { get; set; }
        public decimal? descontoInss { get; set; }

        public decimal? SalarioLiquido { get; set; }




        [Display(Name = "Data de criação")]
        public DateTime dataCriacaoCalculo { get; set; }

        public int? inssid { get; set; }
        public virtual InssModel inssrefmodel { get; set; }

    }
}