using System.ComponentModel.DataAnnotations.Schema;

namespace MalweeTest.Entities.ViewModel
{
    [NotMapped]
    public class TopClienteViewModel
    {
        public Cliente Cliente { get; set; }
        public int Mes { get; set; }
        public decimal Valor { get; set; }

        public override string ToString()
        {
            return Cliente.Nome;
        }
    }
}
