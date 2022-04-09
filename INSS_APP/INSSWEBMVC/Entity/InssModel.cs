using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace INSSWEBMVC.Entity
{
    public class InssModel
    {
      
            [System.ComponentModel.DataAnnotations.Key]
            public int id { get; set; }
            public string ano { get; set; }
            public decimal LimiteSalario { get; set; }
            public decimal porcentagem { get; set; }
          



        [Display(Name = "Data de criação")]
            public DateTime dataCriacao { get; set; }

        public List<CalculoModel> listasalarios { get; set; }


    }

}


    