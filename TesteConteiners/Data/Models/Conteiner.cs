using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteConteiners.Data.Models
{
    public class Conteiner
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        [NotMapped]
        public string NomeCliente { get; set; }
        public string NumeroIdentificao { get; set; }
        public ConteinerEnums.Tipo Tipo { get; set; }
        public ConteinerEnums.Status Status { get; set; }
        public ConteinerEnums.Categoria Categoria { get; set; }
    }
}
