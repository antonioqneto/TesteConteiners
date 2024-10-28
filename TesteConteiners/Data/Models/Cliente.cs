using System.ComponentModel.DataAnnotations;

namespace TesteConteiners.Data.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Nome { get; set; }
    }
}
