using TesteBC.Domain.Models;

namespace TesteBC.Service.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<LancamentoModel>> GetReportLancamentoDiarios(DateTime date);
    }
}
