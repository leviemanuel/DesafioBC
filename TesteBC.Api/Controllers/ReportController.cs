using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TesteBC.Api.Models.Reports;
using TesteBC.Api.Models.Response;
using TesteBC.Service.Interfaces;

namespace TesteBC.Api.Controllers
{
    ///<Summary>
    /// Controller referente aos Reports
    ///</Summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IReportService _service;

        ///<Summary>
        /// Construtor
        ///</Summary>
        public ReportController(IMapper mapper, IReportService service)
        {
            _mapper = mapper;
            _service = service;
        }


        /// <summary>
        /// Busca lançamentos diários
        /// </summary>
        /// <param name="dtLanctos">Data dos Lançamentos</param>
        /// <returns>Retorna os lançamentos diários para a data informada</returns>
        /// <response code="200">Retorna a lista dos lançamentos do dia solicitado</response>
        /// <response code="204">Caso não encontre lançamento algum</response>
        /// <response code="500">Em caso de erro</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BCAPIDefaultResponse<List<LancamentosDiarioDTO>>), 204)]
        [ProducesResponseType(typeof(BCAPIDefaultResponse<object>), 500)]
        public async Task<ActionResult<BCAPIDefaultResponse<LancamentosDiarioDTO>>> LancamentosDiarios([FromQuery] DateTime dtLanctos)
        {
            try
            {
                var lanctos = await _service.GetReportLancamentoDiarios(dtLanctos);

                if (lanctos.Count() > 0)
                    return Ok(new BCAPIDefaultResponse<List<LancamentosDiarioDTO>>(System.Net.HttpStatusCode.OK, _mapper.Map<List<LancamentosDiarioDTO>>(lanctos.ToList())));
                else
                    return Ok(new BCAPIDefaultResponse<List<LancamentosDiarioDTO>>(System.Net.HttpStatusCode.NotFound, _mapper.Map<List<LancamentosDiarioDTO>>(lanctos.ToList())));
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return StatusCode(500, new BCAPIDefaultResponse<List<LancamentosDiarioDTO>>(System.Net.HttpStatusCode.InternalServerError, ex));
            }
        }

    }
}
