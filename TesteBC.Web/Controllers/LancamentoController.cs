using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TesteBC.Web.Services.Interfaces;
using TesteBC.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TesteBC.Web.Controllers
{
    public class LancamentoController : Controller
    {
        private readonly ILogger<LancamentoController> _logger;
        private readonly ILancamentoService _LancamentoService;
        private readonly IEntidadeService _EntidadeService;
        public LancamentoController(ILogger<LancamentoController> logger, ILancamentoService reportService, IEntidadeService entidadeService)
        {
            _logger = logger;
            _LancamentoService = reportService;
            _EntidadeService = entidadeService;
        }

        public async Task<IActionResult> LancamentoLista()
        {
            try
            {
                var response = await _LancamentoService.BuscaTodos();

                if (response.FlSuccess)
                    return View(response.Result);
                else
                    return View("~/Views/Shared/ErrorDetail.cshtml", new ErrorDetailModel(response.ErrorMessage, response.StatusCode));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return View("~/Views/Shared/ErrorDetail.cshtml", new ErrorDetailModel(ex.Message, System.Net.HttpStatusCode.BadRequest));
            }
        }

        public async Task<IActionResult> LancamentoCreate()
        {
            var response = await _EntidadeService.BuscaTodos();

            if (!response.FlSuccess)
                return View("~/Views/Shared/ErrorDetail.cshtml", new ErrorDetailModel(response.ErrorMessage, response.StatusCode));

            var lancamento = new LancamentoModel();

            if (response.Result != null)
                lancamento.entidades = (response.Result.Select(e => new SelectListItem() { Value = e.idEntidade.ToString(), Text = e.nome, Selected = (e.idEntidade == lancamento.entidadeId) })).AsEnumerable();

            return View(lancamento);
        }

        [HttpPost]
        public async Task<IActionResult> LancamentoCreate(LancamentoModel Lancamento)
        {
            if (ModelState.IsValid)
            {
                Lancamento.idLancamento = Guid.NewGuid();
                var response = await _LancamentoService.Adiciona(Lancamento);

                if (response.FlSuccess)
                    return RedirectToAction("LancamentoLista");
                else
                    return View("~/Views/Shared/ErrorDetail.cshtml", new ErrorDetailModel(response.ErrorMessage, response.StatusCode));
            }
            else
            {
                var response = await _EntidadeService.BuscaTodos();

                if (response.Result != null)
                {
                    Lancamento.entidades = (response.Result.Select(e => new SelectListItem() { Value = e.idEntidade.ToString(), Text = e.nome, Selected = (e.idEntidade == Lancamento.entidadeId) })).AsEnumerable();
                    Lancamento.errorMessage = "Dados inválidos";
                }
                else
                    Lancamento.errorMessage = "Dados inválidos - Cadastre Entidades para poder cadastrar Lançamentos";

                return View(Lancamento);
            }
        }

        public async Task<IActionResult> LancamentoAlter(Guid id)
        {
            var lancamento = await _LancamentoService.BuscaLancamento(id);

            if (lancamento.FlSuccess)
            {
                var response = await _EntidadeService.BuscaTodos();
                lancamento.Result.entidades = (response.Result.Select(e => new SelectListItem() { Value = e.idEntidade.ToString(), Text = e.nome, Selected = (e.idEntidade == lancamento.Result.idLancamento) })).AsEnumerable();
                return View(lancamento.Result);
            }
            else
                return View("~/Views/Shared/ErrorDetail.cshtml", new ErrorDetailModel(lancamento.ErrorMessage, lancamento.StatusCode));
        }

        [HttpPost]
        public async Task<IActionResult> LancamentoAlter(LancamentoModel Lancamento)
        {
            var response = await _LancamentoService.Atualiza(Lancamento);

            if (response.FlSuccess)
                return RedirectToAction("LancamentoLista");
            else
                return View("~/Views/Shared/ErrorDetail.cshtml", new ErrorDetailModel(response.ErrorMessage, response.StatusCode));
        }

        public async Task<IActionResult> LancamentoRemove(Guid id)
        {
            var response = await _LancamentoService.BuscaLancamento(id);

            if (response.FlSuccess)
                return View(response.Result);
            else
                return View("~/Views/Shared/ErrorDetail.cshtml", new ErrorDetailModel(response.ErrorMessage, response.StatusCode));
        }

        [HttpPost]
        public async Task<IActionResult> LancamentoRemove(LancamentoModel Lancamento)
        {
            var response = await _LancamentoService.Remove(Lancamento);

            if (response.FlSuccess)
                return RedirectToAction("LancamentoLista");
            else
                return View("~/Views/Shared/ErrorDetail.cshtml", new ErrorDetailModel(response.ErrorMessage, response.StatusCode));
        }

        public async Task<IActionResult> LancamentoDetail(Guid id)
        {
            var lancamento = await _LancamentoService.BuscaLancamento(id);
            if (!lancamento.FlSuccess)
                return View("~/Views/Shared/ErrorDetail.cshtml", new ErrorDetailModel(lancamento.ErrorMessage, lancamento.StatusCode));

            var entidades = await _EntidadeService.BuscaTodos();
            if (!entidades.FlSuccess)
                return View("~/Views/Shared/ErrorDetail.cshtml", new ErrorDetailModel(entidades.ErrorMessage, entidades.StatusCode));

            lancamento.Result.entidadeNome = entidades.Result.First(en => en.idEntidade == lancamento.Result.entidadeId).nome;

            return View(lancamento.Result);
        }
    }
}
