using TesteConteiners.Data;
using TesteConteiners.Data.Models;

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
