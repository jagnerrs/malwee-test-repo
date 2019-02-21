using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MalweeTest.Entities
{
    [Table("ServicoPrestado")]
    public class ServicoPrestado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [Column("CLIENTE")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        [Display(Name = "Cliente")]
        public Cliente Cliente { get; set; }

        [Column("FORNECEDOR")]
        public int FornecedorId { get; set; }

        [ForeignKey("FornecedorId")]
        public Fornecedor Fornecedor { get; set; }

        [Column("DESCRICAO")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Column("DATA")]
        public DateTime Data { get; set; }

        [Column("VALOR")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N}")]
        public decimal? Valor { get; set; }

        [Column("TIPO")]
        public string Tipo { get; set; }
    }
}
