using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TesteBC.Api.Models.DTO;
using TesteBC.Api.Models.Response;
using TesteBC.Domain.Models;
using TesteBC.Service.Interfaces;

namespace TesteBC.Api.Controllers
{
    ///<Summary>
    /// Controller referente aos Lançamentos
    ///</Summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILancamentoService _service;

        ///<Summary>
        /// Cosntrutor
        ///</Summary>
        public LancamentoController(IMapper mapper, ILancamentoService service)
        {
            _mapper = mapper;
            _service = service;
        }

        /// <summary>
        /// Busca todos os lançamentos cadastrados
        /// </summary>
        /// <returns>Lista de todos os lançamentos</returns>
        /// <response code="200">Retorna os lançamentos</response>
        /// <response code="204">Caso não encontre lançamento algum</response>
        /// <response code="500">Em caso de erro</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(BCAPIDefaultResponse<object>), 204)]
        [ProducesResponseType(typeof(BCAPIDefaultResponse<object>), 500)]
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

        /// <summary>
        /// Busca lançamento com o código informado
        /// </summary>
        /// <param name="id">Id (GUID) do lançamento</param>
        /// <returns>Retorna o lançamento do id informado</returns>
        /// <response code="200">Retorna o lançamento do id enviado</response>
        /// <response code="204">Caso não encontre lançamento algum</response>
        /// <response code="500">Em caso de erro</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BCAPIDefaultResponse<LancamentoReadDTO>), 204)]
        [ProducesResponseType(typeof(BCAPIDefaultResponse<object>), 500)]
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

        /// <summary>
        /// Insere o lançamento passado
        /// </summary>
        /// <param name="lancto">Lançamento a ser inserido</param>
        /// <response code="201">Retorna sucesso</response>
        /// <response code="400">Caso algum dado esteja inválido</response>
        /// <response code="500">Em caso de erro catastrófico</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BCAPIDefaultResponse<object>), 400)]
        [ProducesResponseType(typeof(BCAPIDefaultResponse<object>), 500)]
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

        /// <summary>
        /// Altera o lançamento enviado
        /// </summary>
        /// <param name="id">Id (GUID) do lançamento a ser alterado</param>
        /// <param name="lancto">Lançamento com os novos valores</param>
        /// <response code="204">Retorna sucesso</response>
        /// <response code="400">Caso algum dado esteja inválido</response>
        /// <response code="500">Em caso de erro catastrófico</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(BCAPIDefaultResponse<object>), 400)]
        [ProducesResponseType(typeof(BCAPIDefaultResponse<object>), 500)]
        public async Task<ActionResult<BCAPIDefaultResponse<LancamentoReadDTO>>> AtualizaLancamento(Guid id, LancamentoUpdateDTO lancto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var original = await _service.BuscaLancamento(id);

                    if (original == null)
                        return Ok(new BCAPIDefaultResponse<LancamentoReadDTO>(System.Net.HttpStatusCode.NotFound, result: null));

                    if (original.IdLancamento != lancto.IdLancamento)
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

        /// <summary>
        /// Remove lançamento
        /// </summary>
        /// <param name="id">Id (GUID) do lançamento a removido</param>
        /// <response code="204">Retorna sucesso</response>
        /// <response code="400">Caso algum dado esteja inválido</response>
        /// <response code="500">Em caso de erro catastrófico</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(BCAPIDefaultResponse<object>), 400)]
        [ProducesResponseType(typeof(BCAPIDefaultResponse<object>), 500)]
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
