using TesteBC.Web.Models;
using TesteBC.Web.Models.Report;

namespace TesteBC.Web.Services.Interfaces
{
    public interface IReportService
    {
        Task<APIResponse<IEnumerable<LancamentoDiarioReportResult>>> GetReportLancamentoDiarios(DateTime date);
    }
}
