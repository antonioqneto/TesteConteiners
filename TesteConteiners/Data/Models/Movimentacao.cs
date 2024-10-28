using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteConteiners.Data.Models
{
    public class Movimentacao
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Conteiner")]
        public int? ConteinerId { get; set; }
        [NotMapped]
        public string NomeConteiner { get; set; }
        public ConteinerEnums.TipoMovimentacao Tipo { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
    }
}
