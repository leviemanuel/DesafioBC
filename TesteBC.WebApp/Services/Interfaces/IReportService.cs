using TesteBC.WebApp.Models.Report;

namespace TesteBC.WebApp.Services.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<LancamentoDiarioReportResult>> GetReportLancamentoDiarios(DateTime date);
    }
}
