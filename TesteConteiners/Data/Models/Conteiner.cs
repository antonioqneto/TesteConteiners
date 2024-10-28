using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteConteiners.Data.Models
{
    public class Conteiner
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Cliente")]
        public int? ClienteId { get; set; }
        [NotMapped]
        public string NomeCliente { get; set; }
        [Required, MaxLength(11)]
        public string NumeroIdentificao { get; set; }
        public ConteinerEnums.Tipo Tipo { get; set; }
        public ConteinerEnums.Status Status { get; set; }
        public ConteinerEnums.Categoria Categoria { get; set; }
    }

    public class ConteinerValidator : AbstractValidator<Conteiner>
    {
        public ConteinerValidator()
        {
            RuleFor(x => x.NumeroIdentificao).NotEmpty().WithMessage("Número de identificação é obrigatório")
                                             .Length(11).WithMessage("Número de identificação deve ter 11 caracteres")
                                             .Matches("^[a-zA-Z]{4}\\d{7}$").WithMessage("O número deve começar com 4 letras e terminar com 7 dígitos");

            RuleFor(x => x.Tipo).IsInEnum().WithMessage("Tipo inválido");
            RuleFor(x => x.Status).IsInEnum().WithMessage("Status inválido");
            RuleFor(x => x.Categoria).IsInEnum().WithMessage("Categoria inválida");
        }
    }
}
