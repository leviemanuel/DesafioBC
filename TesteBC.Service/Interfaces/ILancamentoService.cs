using TesteBC.Domain.Models;

namespace TesteBC.Service.Interfaces
{
    public interface ILancamentoService : ICRUDService<LancamentoModel>
    {
        Task<LancamentoModel> BuscaLancamento(Guid id);
    }
}
