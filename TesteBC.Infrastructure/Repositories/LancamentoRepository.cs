using Microsoft.EntityFrameworkCore;
using TesteBC.Domain.Models;
using TesteBC.Infrastructure.Data.Context;
using TesteBC.Infrastructure.Repositories.Interfaces;

namespace TesteBC.Infrastructure.Repositories
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private readonly TesteBCDBContext _dbContext;

        public LancamentoRepository(TesteBCDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<LancamentoModel>> BuscaTodos()
        {
            return await _dbContext.Lancamentos.ToListAsync();
        }
        public async Task Adiciona(LancamentoModel obj)
        {
            await _dbContext.Lancamentos.AddAsync(obj);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Atualiza(LancamentoModel obj)
        {
            _dbContext.Lancamentos.Update(obj);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Remove(LancamentoModel entity)
        {
            _dbContext.Lancamentos.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<LancamentoModel> BuscaLancamento(Guid id)
        {
            return await _dbContext.Lancamentos.FirstOrDefaultAsync(t => t.idLancamento == id);
        }
    }
}
