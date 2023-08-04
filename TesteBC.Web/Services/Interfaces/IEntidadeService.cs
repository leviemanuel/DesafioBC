using TesteBC.Web.Models;
namespace TesteBC.Web.Services.Interfaces
{
    public interface IEntidadeService
    {
        Task<APIResponse<IEnumerable<EntidadeModel>>?> BuscaTodos();
        Task<APIResponse<EntidadeModel>?> Adiciona(EntidadeModel obj);
        Task<APIResponse<EntidadeModel>?> Atualiza(EntidadeModel obj);
        Task<APIResponse<EntidadeModel>?> Remove(EntidadeModel obj);
        Task<APIResponse<EntidadeModel>?> BuscaEntidade(Guid id);
        Task<APIResponse<EntidadeModel>?> BuscaEntidadePorDocumento(string documento);

    }
}
