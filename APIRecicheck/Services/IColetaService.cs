using APIRecicheck.Data.Contexts;
using APIRecicheck.Models;

namespace APIRecicheck.Services
{
    public interface IColetaService
    {

        IEnumerable<ColetaModel> ListarModel(int pagina = 0, int tamanho = 10);
   
        IEnumerable<ColetaModel> ListarColetas();

        ColetaModel ObterColetaPorID(int id);

        void CadastrarColeta(ColetaModel coletaModel);
        void AtualizarColeta(ColetaModel coletaModel);
        void DeletarColeta(int id);
    }
}
