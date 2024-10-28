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

    public record MovimentacaoViewModel
    {
        public int? ClienteId { get; set; }
        public string NomeCliente { get; set; }
        public ConteinerEnums.Categoria Categoria { get; set; }
        public ConteinerEnums.TipoMovimentacao TipoMovimentacao { get; set; }
    }
    public record RelatorioMovimentacoes(List<MovimentacaoViewModel> dados)
    {
        public int? ClienteId => dados.Select(x => x.ClienteId).FirstOrDefault();
        public string NomeCliente => dados?.Select(x => x.NomeCliente)?.FirstOrDefault() ?? string.Empty;
        public int TotalEmbarque => dados.Where(x => x.TipoMovimentacao == ConteinerEnums.TipoMovimentacao.Embarque).Count();
        public int TotalDescarga => dados.Where(x => x.TipoMovimentacao == ConteinerEnums.TipoMovimentacao.Descarga ).Count();
        public int TotalGateIn => dados.Where(x => x.TipoMovimentacao == ConteinerEnums.TipoMovimentacao.GateIn ).Count();
        public int TotalGateOut => dados.Where(x => x.TipoMovimentacao == ConteinerEnums.TipoMovimentacao.GateOut ).Count();
        public int TotalReposicionamento => dados.Where(x => x.TipoMovimentacao == ConteinerEnums.TipoMovimentacao.Reposicionamento ).Count();
        public int TotalPesagem => dados.Where(x => x.TipoMovimentacao == ConteinerEnums.TipoMovimentacao.Pesagem ).Count();
        public int TotalScanner => dados.Where(x => x.TipoMovimentacao == ConteinerEnums.TipoMovimentacao.Scanner).Count();
        public int TotalMovimentacoes => dados.Where(x => Enum.IsDefined(x.TipoMovimentacao)).Count();
    }
}
