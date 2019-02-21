using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace MalweeTest.Entities.ViewModel
{
    [NotMapped]
    public class FilterServicoPrestadoViewModel
    {
        [Display(Name="De")]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Até")]
        public DateTime DataFim { get; set; }

        [Display(Name = "De")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N}")]
        public decimal? ValorMinimo { get; set; }

        [Display(Name = "Até")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N}")]
        public decimal? ValorMaximo { get; set; }

        [Display(Name = "Cliente")]
        public int Cliente { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Display(Name = "Tipo Serviço")]
        public string TipoServico { get; set; }


        public SelectList DropDownClientes { get; set; }
        public SelectList DropDownTipoServico { get; set; }
    }
}
