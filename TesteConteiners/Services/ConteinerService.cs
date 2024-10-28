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
        public Conteiner GetConteinerById(int id)
        {
            var result = _db.Conteiners.Where(x => x.Id == id).FirstOrDefault();
            return result;
        }
        public List<Conteiner> GetConteiner()
        {
            var result = _db.Conteiners.ToList();
            return result;
        }
        public void UpdateConteiner(Conteiner conteiner)
        {
            _db.Conteiners.Update(conteiner);
            _db.SaveChanges();
        }
        public void DeleteConteiner(Conteiner conteiner)
        {
            _db.Conteiners.Remove(conteiner);
            _db.SaveChanges();
        }
    }
}
