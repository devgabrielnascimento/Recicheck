using APIRecicheck.Models;

namespace APIRecicheck.Data.Repository
{
    public interface IColetaRepository
    {
        IEnumerable<ColetaModel> GetAll(int page, int size);
        IEnumerable<ColetaModel> GetALL();

        ColetaModel GetById(int id);

        void Add(ColetaModel coletaModel);
        void Update(ColetaModel coletaModel);
        void Delete(ColetaModel coletaModel);


    }
}
