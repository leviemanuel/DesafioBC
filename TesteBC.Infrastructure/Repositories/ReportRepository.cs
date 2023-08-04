using Microsoft.EntityFrameworkCore;
using TesteBC.Domain.Models;
using TesteBC.Infrastructure.Data.Context;
using TesteBC.Infrastructure.Repositories.Interfaces;

namespace TesteBC.Infrastructure.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly TesteBCDBContext _dbContext;

        public ReportRepository(TesteBCDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<LancamentoModel>> GetReportLancamentoDiarios(DateTime date)
        {
            return await _dbContext.Lancamentos.Where(t => t.DtPagamento.Date == date.Date).ToListAsync();
        }
    }
}
