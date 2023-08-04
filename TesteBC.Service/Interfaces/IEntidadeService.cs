using TesteBC.Domain.Models;

namespace TesteBC.Service.Interfaces
{
    public interface IEntidadeService : ICRUDService<EntidadeModel>
    {
        Task<EntidadeModel?> BuscaEntidade(Guid id);
        Task<EntidadeModel?> BuscaEntidadePorDocumento(string documento);
    }
}
