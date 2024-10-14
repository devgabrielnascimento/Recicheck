using APIRecicheck.Data.Contexts;
using APIRecicheck.Models;
using Microsoft.EntityFrameworkCore;

namespace APIRecicheck.Data.Repository
{


    public class ColetaRepository : IColetaRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ColetaRepository(DatabaseContext context)
        {
            _databaseContext = context;
        }
        
        public void Add(ColetaModel coletaModel)
        {
            _databaseContext.Coletas.Add(coletaModel);
            _databaseContext.SaveChanges();
        }

        public void Delete(ColetaModel coletaModel)
        {
            _databaseContext.Coletas.Remove(coletaModel);
            _databaseContext.SaveChanges();
        }

        public IEnumerable<ColetaModel> GetALL()
        {
            return _databaseContext.Coletas.ToList(); ;
        }

        public ColetaModel GetById(int id)
        {
            return _databaseContext.Coletas.Find(id);
        }

        public void Update(ColetaModel coletaModel)
        {
            _databaseContext.Coletas.Update(coletaModel);
            _databaseContext.SaveChanges();
        }

        public IEnumerable<ColetaModel> GetAll(int page, int size)
        {
            return _databaseContext.Coletas
                            .Skip((page - 1) * page)
                            .Take(size)
                            .AsNoTracking()
                            .ToList();
        }
    }
}
