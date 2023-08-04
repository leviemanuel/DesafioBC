using TesteBC.Domain.Models;

namespace TesteBC.Infrastructure.Repositories.Interfaces
{
    public interface IEntidadeRepository : IRepository<EntidadeModel>
    {
        Task<EntidadeModel?> BuscaEntidade(Guid id);
        Task<EntidadeModel?> BuscaEntidadePorDocumento(string doc);
    }
}
