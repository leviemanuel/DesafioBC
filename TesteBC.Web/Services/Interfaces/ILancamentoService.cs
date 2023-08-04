using TesteBC.Web.Models;

namespace TesteBC.Web.Services.Interfaces
{
    public interface ILancamentoService
    {
        Task<APIResponse<IEnumerable<LancamentoModel>>> BuscaTodos();
        Task<APIResponse<LancamentoModel>?> Adiciona(LancamentoModel obj);
        Task<APIResponse<LancamentoModel>?> Atualiza(LancamentoModel obj);
        Task<APIResponse<LancamentoModel>?> Remove(LancamentoModel obj);
        Task<APIResponse<LancamentoModel>?> BuscaLancamento(Guid id);
    }
}
