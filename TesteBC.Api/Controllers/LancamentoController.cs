using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TesteBC.Api.Models.DTO;
using TesteBC.Api.Models.Response;
using TesteBC.Domain.Models;
using TesteBC.Service.Interfaces;

namespace TesteBC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILancamentoService _service;

        public LancamentoController(IMapper mapper, ILancamentoService service)
        {
            _mapper = mapper;
            _service = service;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BCAPIDefaultResponse<List<LancamentoReadDTO>>>> BuscaLancamentos()
        {
            try
            {
                var lanctos = await _service.BuscaTodos();

                if (lanctos.Count() > 0)
                    return Ok(new BCAPIDefaultResponse<List<LancamentoReadDTO>>(System.Net.HttpStatusCode.OK, _mapper.Map<List<LancamentoReadDTO>>(lanctos.ToList())));
                else
                    return Ok(new BCAPIDefaultResponse<List<LancamentoReadDTO>>(System.Net.HttpStatusCode.NoContent, result: null));
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return StatusCode(500, new BCAPIDefaultResponse<List<LancamentoReadDTO>>(System.Net.HttpStatusCode.InternalServerError, ex));
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BCAPIDefaultResponse<LancamentoReadDTO>>> BuscaLancamento(Guid id)
        {
            try
            {
                LancamentoModel lancto = await _service.BuscaLancamento(id);

                if (lancto != null)
                    return Ok(new BCAPIDefaultResponse<LancamentoReadDTO>(System.Net.HttpStatusCode.OK, _mapper.Map<LancamentoReadDTO>(lancto)));
                else
                    return Ok(new BCAPIDefaultResponse<LancamentoReadDTO>(System.Net.HttpStatusCode.NotFound, result: null));
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return StatusCode(500, new BCAPIDefaultResponse<List<LancamentoReadDTO>>(System.Net.HttpStatusCode.InternalServerError, ex));
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BCAPIDefaultResponse<LancamentoReadDTO>>> InsereLancamento(LancamentoCreateDTO lancto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (lancto.EntidadeId != Guid.Empty)
                    {
                        LancamentoModel l = _mapper.Map<LancamentoModel>(lancto);
                        await _service.Adiciona(_mapper.Map<LancamentoModel>(lancto));

                        return Ok(new BCAPIDefaultResponse<LancamentoReadDTO>(System.Net.HttpStatusCode.OK, _mapper.Map<LancamentoReadDTO>(lancto)));
                    }
                    else
                    {
                        return BadRequest(new BCAPIDefaultResponse<LancamentoReadDTO>(System.Net.HttpStatusCode.BadRequest, "Informe uma entidade válida"));
                    }
                }
                else
                    return BadRequest(new BCAPIDefaultResponse<LancamentoReadDTO>(System.Net.HttpStatusCode.BadRequest, "Dados inválidos"));

            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return StatusCode(500, new BCAPIDefaultResponse<List<LancamentoReadDTO>>(System.Net.HttpStatusCode.InternalServerError, ex));
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BCAPIDefaultResponse<LancamentoReadDTO>>> AtualizaLancamento(Guid id, LancamentoUpdateDTO lancto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var original = await _service.BuscaLancamento(id);

                    if (original == null)
                        return Ok(new BCAPIDefaultResponse<LancamentoReadDTO>(System.Net.HttpStatusCode.NotFound, result: null));

                    if (original.idLancamento != lancto.idLancamento)
                        return BadRequest(new BCAPIDefaultResponse<LancamentoReadDTO>(System.Net.HttpStatusCode.BadRequest, "Dados inválidos"));

                    _mapper.Map(lancto, original);
                    await _service.Atualiza(original);

                    return Ok(new BCAPIDefaultResponse<LancamentoReadDTO>(System.Net.HttpStatusCode.NoContent, _mapper.Map<LancamentoReadDTO>(lancto)));
                }
                else
                    return BadRequest(new BCAPIDefaultResponse<LancamentoReadDTO>(System.Net.HttpStatusCode.BadRequest, "Dados inválidos"));

            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return StatusCode(500, new BCAPIDefaultResponse<List<LancamentoReadDTO>>(System.Net.HttpStatusCode.InternalServerError, ex));
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LancamentoReadDTO>> RemoveLancamento(Guid id)
        {
            try
            {
                if (!id.Equals(Guid.Empty))
                {
                    var original = await _service.BuscaLancamento(id);

                    if (original == null)
                        return NotFound();

                    await _service.Remove(original);

                    return Ok(new BCAPIDefaultResponse<LancamentoReadDTO>(System.Net.HttpStatusCode.NoContent, result: null));
                }
                else
                    return BadRequest(new BCAPIDefaultResponse<LancamentoReadDTO>(System.Net.HttpStatusCode.BadRequest, "Dados inválidos"));
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return StatusCode(500, new BCAPIDefaultResponse<List<LancamentoReadDTO>>(System.Net.HttpStatusCode.InternalServerError, ex));
            }
        }
    }
}
