using TesteConteiners.Data;
using TesteConteiners.Data.Models;
using static TesteConteiners.Data.Models.ConteinerEnums;

namespace TesteMovimentacoes.Services
{
    public class MovimentacaoService
    {
        private readonly AppDbContext _db;

        public MovimentacaoService(AppDbContext db)
        {
            _db = db;
        }

        public void CreateMovimentacao(Movimentacao Movimentacao)
        {
            _db.Movimentacoes.Add(Movimentacao);
            _db.SaveChanges();
        }
        public Movimentacao GetMovimentacaoById(int id)
        {
            var result = _db.Movimentacoes.Where(x => x.Id == id).FirstOrDefault();
            return result;
        }
        public List<Movimentacao> GetMovimentacao()
        {
            var result = _db.Movimentacoes.ToList();
            return result;
        }
        
        public List<MovimentacaoViewModel> GetDadosRelatorio()
        {
            var result = (from cl in _db.Clientes
                          join c in _db.Conteiners on cl.Id equals c.ClienteId into cg
                          from c in cg.DefaultIfEmpty()
                          join m in _db.Movimentacoes on c.Id equals m.ConteinerId into mg
                          from m in mg.DefaultIfEmpty()
                          select new MovimentacaoViewModel
                          {
                              ClienteId = cl.Id,
                              NomeCliente = cl.Nome,
                              Categoria = c != null ? c.Categoria : default,
                              TipoMovimentacao = m != null ? m.Tipo : default
                          }).ToList();

            return result;
        }


        public void UpdateMovimentacao(Movimentacao Movimentacao)
        {
            _db.Movimentacoes.Update(Movimentacao);
            _db.SaveChanges();
        }
        public void DeleteMovimentacao(Movimentacao Movimentacao)
        {
            _db.Movimentacoes.Remove(Movimentacao);
            _db.SaveChanges();
        }
    }
}
