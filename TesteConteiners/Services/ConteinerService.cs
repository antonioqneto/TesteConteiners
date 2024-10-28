using TesteConteiners.Data;
using TesteConteiners.Data.Models;

namespace TesteConteiners.Services
{
    public class ConteinerService
    {
        private readonly AppDbContext _db;

        public ConteinerService(AppDbContext db)
        {
            _db = db;
        }

        public void CreateConteiner(Conteiner conteiner)
        {
            _db.Conteiners.Add(conteiner);
            _db.SaveChanges();
        }
        public List<Cliente> GetClientes()
        {
            var result = _db.Clientes.ToList();
            return result;
        }
        public Conteiner GetConteinerById(int id)
        {
            var result = _db.Conteiners.Where(x => x.Id == id).FirstOrDefault();
            return result;
        }
        public List<Conteiner> GetConteiner()
        {
            var result = _db.Conteiners.ToList();

            if (result == null) return new();

            result.ForEach(x =>
            {
                x.NomeCliente = _db.Clientes?.FirstOrDefault(y => y.Id == x.ClienteId)?.Nome ?? string.Empty;
            });

            return result;
        }
        public void UpdateConteiner(Conteiner conteiner)
        {
            _db.Conteiners.Update(conteiner);
            _db.SaveChanges();
        }
        public bool DeleteConteiner(Conteiner conteiner)
        {
            var result = _db.Conteiners.Remove(conteiner);
            if (result == null) return false;

            return _db.SaveChanges() > 0;
        }
    }
}
