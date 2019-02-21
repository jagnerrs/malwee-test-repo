using System.ComponentModel.DataAnnotations.Schema;

namespace MalweeTest.Entities.ViewModel
{
    [NotMapped]
    public class FornecedorInativoViewModel
    {
        public int Mes { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}
