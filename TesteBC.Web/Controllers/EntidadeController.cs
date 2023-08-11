using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TesteBC.Web.Models;
using TesteBC.Web.Services.Interfaces;

namespace TesteBC.Web.Controllers
{
    public class EntidadeController : Controller
    {
        private readonly ILogger<EntidadeController> _logger;
        private readonly IEntidadeService _entidadeService;
        public EntidadeController(ILogger<EntidadeController> logger, IEntidadeService reportService)
        {
            _logger = logger;
            _entidadeService = reportService;
        }

        public async Task<IActionResult> EntidadeLista()
        {
            try
            {
                var response = await _entidadeService.BuscaTodos();

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

        public ActionResult EntidadeCreate()
        {
            return View(new EntidadeModel { flAtivo = true, idEntidade = new Guid() });
        }

        [HttpPost]
        public async Task<IActionResult> EntidadeCreate(EntidadeModel entidade)
        {
            entidade.idEntidade = Guid.NewGuid();

            var response = await _entidadeService.Adiciona(entidade);

            if (response.FlSuccess)
                return RedirectToAction("EntidadeLista");
            else
            {
                entidade.errorMessage = response.ErrorMessage;
                return View(entidade);
            }

        }

        public async Task<IActionResult> EntidadeAlter(Guid id)
        {
            var response = await _entidadeService.BuscaEntidade(id);

            if (response.FlSuccess)
                return View(response.Result);
            else
                return View("~/Views/Shared/ErrorDetail.cshtml", new ErrorDetailModel(response.ErrorMessage, response.StatusCode));
        }

        [HttpPost]
        public async Task<IActionResult> EntidadeAlter(EntidadeModel entidade)
        {
            var response = await _entidadeService.Atualiza(entidade);

            if (response != null && response.FlSuccess)
                return RedirectToAction("EntidadeLista");
            else
            {
                entidade.errorMessage = response.ErrorMessage;
                return View(entidade);
            }
        }

        public async Task<IActionResult> EntidadeRemove(Guid id)
        {
            var response = await _entidadeService.BuscaEntidade(id);

            if (response != null && response.FlSuccess)
                return View(response.Result);
            else
                return View("~/Views/Shared/ErrorDetail.cshtml", new ErrorDetailModel(response.ErrorMessage, response.StatusCode));
        }

        [HttpPost]
        public async Task<IActionResult> EntidadeRemove(EntidadeModel entidade)
        {
            var response = await _entidadeService.Remove(entidade);

            if (response.FlSuccess)
                return RedirectToAction("EntidadeLista");
            else
            {
                entidade.errorMessage = response.ErrorMessage;
                return View(entidade);
            }
        }
    }
}
