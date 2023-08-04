using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TesteBC.Api.Models.Reports;
using TesteBC.Api.Models.Response;
using TesteBC.Service.Interfaces;

namespace TesteBC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IReportService _service;

        public ReportController(IMapper mapper, IReportService service)
        {
            _mapper = mapper;
            _service = service;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
