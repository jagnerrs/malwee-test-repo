using System.ComponentModel.DataAnnotations.Schema;

namespace MalweeTest.Entities.ViewModel
{
    [NotMapped]
    public class CustoMedioViewModel
    {
        public decimal Valor { get; set; }
        public string TipoServico { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}
