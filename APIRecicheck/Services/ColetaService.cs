using APIRecicheck.Data.Contexts;
using APIRecicheck.Data.Repository;
using APIRecicheck.Models;

namespace APIRecicheck.Services
{
    public class ColetaService : IColetaService
    {
        private readonly IColetaRepository _repository;

        public ColetaService(IColetaRepository repository)
        {
            _repository = repository;
        }

        public void CadastrarColeta(ColetaModel coletaModel) => _repository.Add(coletaModel);
        public void AtualizarColeta(ColetaModel coletaModel) => _repository.Update(coletaModel);
        public void DeletarColeta(int id)
        {
            var coletas = _repository.GetById(id);
            if (coletas != null)
            {
                _repository.Delete(coletas);
            }
        }

        public IEnumerable<ColetaModel> ListarColetas() => _repository.GetALL(); 
   
        public ColetaModel ObterColetaPorID(int id) => _repository.GetById(id);

        public IEnumerable<ColetaModel> ListarModel(int pagina = 1, int tamanho = 10)
        {
            return _repository.GetAll(pagina, tamanho);
        }
       

    }
}
