using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TesteBC.WebApp.Models.Report;
using TesteBC.WebApp.Services.Interfaces;

namespace TesteBC.WebApp.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        public async Task<IActionResult> Index()
        {
            var lanctos = await GetReportLancamentosDiario();
            return View(lanctos);
        }

        private async Task<IEnumerable<LancamentoDiarioReportResult>> GetReportLancamentosDiario()
        {
            try
            {
                return await _reportService.GetReportLancamentoDiarios(DateTime.Now.AddDays(-1));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return Enumerable.Empty<LancamentoDiarioReportResult>();
            }
        }
    }
}
