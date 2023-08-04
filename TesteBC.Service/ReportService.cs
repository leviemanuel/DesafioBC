using TesteBC.Domain.Models;
using TesteBC.Infrastructure.Repositories.Interfaces;
using TesteBC.Service.Interfaces;

namespace TesteBC.Service
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepo;

        public ReportService(IReportRepository reportRepo)
        {
            _reportRepo = reportRepo;
        }
        public async Task<IEnumerable<LancamentoModel>> GetReportLancamentoDiarios(DateTime date)
        {
            return await _reportRepo.GetReportLancamentoDiarios(date);
        }
    }
}
