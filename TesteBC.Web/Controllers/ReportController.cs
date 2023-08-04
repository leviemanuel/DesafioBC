using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TesteBC.Web.Models;
using TesteBC.Web.Models.Report;
using TesteBC.Web.Services.Interfaces;

namespace TesteBC.Web.Controllers
{
    public class ReportController : Controller
    {
        private readonly ILogger<ReportController> _logger;
        private readonly IReportService _reportService;
        public ReportController(ILogger<ReportController> logger, IReportService reportService)
        {
            _logger = logger;
            _reportService = reportService;
        }

        public async Task<IActionResult> ReportLancamentosDiario()
        {
            var response = await _reportService.GetReportLancamentoDiarios(DateTime.Now.AddDays(0));

            if (response.FlSuccess)
                return View(new LancamentoDiarioReport() { dtPagamento = DateTime.Now.AddDays(0), LancamentosDiarios = response.Result });
            else
                return View("~/Views/Shared/ErrorDetail.cshtml", new ErrorDetailModel(response.ErrorMessage, response.StatusCode));
        }

        [HttpPost]
        public async Task<IActionResult> ReportLancamentosDiario(LancamentoDiarioReport model)
        {
            var response = await _reportService.GetReportLancamentoDiarios(model.dtPagamento);

            if (response.FlSuccess)
                return View(new LancamentoDiarioReport() { dtPagamento = model.dtPagamento, LancamentosDiarios = response.Result });
            else
                return View("~/Views/Shared/ErrorDetail.cshtml", new ErrorDetailModel(response.ErrorMessage, response.StatusCode));
        }
    }
}
