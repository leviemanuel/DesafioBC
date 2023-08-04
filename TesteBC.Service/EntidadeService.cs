using TesteBC.Domain.Models;
using TesteBC.Infrastructure.Repositories.Interfaces;
using TesteBC.Service.Interfaces;

namespace TesteBC.Service
{
    public class EntidadeService : IEntidadeService
    {
        private readonly IEntidadeRepository _entidadeRepo;

        public EntidadeService(IEntidadeRepository lanctoRepo)
        {
            _entidadeRepo = lanctoRepo;
        }

        public async Task<IEnumerable<EntidadeModel>> BuscaTodos()
        {
            return await _entidadeRepo.BuscaTodos();
        }

        public async Task Adiciona(EntidadeModel obj)
        {
            await _entidadeRepo.Adiciona(obj);
        }

        public async Task Atualiza(EntidadeModel obj)
        {
            await _entidadeRepo.Atualiza(obj);
        }

        public async Task Remove(EntidadeModel obj)
        {
            await _entidadeRepo.Remove(obj);
        }

        public async Task<EntidadeModel?> BuscaEntidade(Guid id)
        {
            return await _entidadeRepo.BuscaEntidade(id);
        }

        public async Task<EntidadeModel?> BuscaEntidadePorDocumento(string documento)
        {
            return await _entidadeRepo.BuscaEntidadePorDocumento(documento);
        }
    }
}
