using TesteBC.Domain.Models;
using TesteBC.Infrastructure.Repositories;
using TesteBC.Infrastructure.Repositories.Interfaces;
using TesteBC.Service.Interfaces;

namespace TesteBC.Service
{
    public class LancamentoService : ILancamentoService
    {
        private readonly ILancamentoRepository _lanctoRepo;

        public LancamentoService(ILancamentoRepository lanctoRepo)
        {
            _lanctoRepo = lanctoRepo;
        }

        public async Task<IEnumerable<LancamentoModel>> BuscaTodos()
        {
            return await _lanctoRepo.BuscaTodos();
        }
        public async Task Adiciona(LancamentoModel obj)
        {
            await _lanctoRepo.Adiciona(obj);
        }

        public async Task Atualiza(LancamentoModel obj)
        {
            await _lanctoRepo.Atualiza(obj);
        }

        public async Task Remove(LancamentoModel obj)
        {
            await _lanctoRepo.Remove(obj);
        }

        public async Task<LancamentoModel> BuscaLancamento(Guid id)
        {
            return await _lanctoRepo.BuscaLancamento(id);
        }
    }
}
