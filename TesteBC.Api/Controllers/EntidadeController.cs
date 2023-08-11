using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TesteBC.Api.Models.DTO;
using TesteBC.Api.Models.Response;
using TesteBC.Domain.Models;
using TesteBC.Service.Interfaces;

namespace TesteBC.Api.Controllers
{
    ///<Summary>
    /// Controller referente as Entidades (Favorecidos)
    ///</Summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EntidadeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEntidadeService _service;


        ///<Summary>
        /// Construtor
        ///</Summary>
        public EntidadeController(IMapper mapper, IEntidadeService service)
        {
            _mapper = mapper;
            _service = service;
        }


        /// <summary>
        /// Busca todas as entidades cadastradas
        /// </summary>
        /// <returns>Retorna objeto contendo todas as entidades da base</returns>
        /// <response code="200">Retorna as entidades</response>
        /// <response code="204">Caso não encontre nenhuma entidade</response>
        /// <response code="500">Em caso de erro</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BCAPIDefaultResponse<object>), 204)]
        [ProducesResponseType(typeof(BCAPIDefaultResponse<object>), 500)]
        public async Task<ActionResult<BCAPIDefaultResponse<List<EntidadeReadDTO>>>> BuscaEntidades()
        {
            try
            {
                var entidades = await _service.BuscaTodos();

                if (entidades.Count() > 0)
                    return Ok(new BCAPIDefaultResponse<List<EntidadeReadDTO>>(System.Net.HttpStatusCode.OK, _mapper.Map<List<EntidadeReadDTO>>(entidades.ToList())));
                else
                    return Ok(new BCAPIDefaultResponse<List<EntidadeReadDTO>>(System.Net.HttpStatusCode.NotFound, result: null));
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return StatusCode(500, new BCAPIDefaultResponse<List<EntidadeReadDTO>>(System.Net.HttpStatusCode.InternalServerError, ex));
            }
        }

        /// <summary>
        /// Busca lançamentos diários
        /// </summary>
        /// <param name="id">Id (GUID) da entidade</param>
        /// <returns>Retorna o lançamento do id informado</returns>
        /// <response code="200">Retorna a entidade referente ao id passado</response>
        /// <response code="204">Caso não encontre entidade alguma</response>
        /// <response code="500">Em caso de erro</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BCAPIDefaultResponse<object>), 204)]
        [ProducesResponseType(typeof(BCAPIDefaultResponse<object>), 500)]
        public async Task<ActionResult<BCAPIDefaultResponse<EntidadeReadDTO>>> BuscaEntidade(Guid id)
        {
            try
            {
                EntidadeModel? entidade = await _service.BuscaEntidade(id);

                if (entidade != null)
                    return Ok(new BCAPIDefaultResponse<EntidadeReadDTO>(System.Net.HttpStatusCode.OK, _mapper.Map<EntidadeReadDTO>(entidade)));
                else
                    return Ok(new BCAPIDefaultResponse<EntidadeReadDTO>(System.Net.HttpStatusCode.NotFound, result: null));
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return StatusCode(500, new BCAPIDefaultResponse<EntidadeReadDTO>(System.Net.HttpStatusCode.InternalServerError, ex));
            }
        }

        /// <summary>
        /// Insere entidade
        /// </summary>
        /// <param name="entidade">Nova entidade</param>
        /// <response code="201">Retorna sucesso</response>
        /// <response code="400">Caso algum dado esteja inválido</response>
        /// <response code="500">Em caso de erro catastrófico</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BCAPIDefaultResponse<object>), 400)]
        [ProducesResponseType(typeof(BCAPIDefaultResponse<object>), 500)]
        public async Task<ActionResult<BCAPIDefaultResponse<EntidadeCreateDTO>>> InsereEntidade(EntidadeCreateDTO entidade)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var original = await _service.BuscaEntidadePorDocumento(entidade.Documento);

                    if (original != null)
                        return BadRequest(new BCAPIDefaultResponse<EntidadeReadDTO>(System.Net.HttpStatusCode.BadRequest, "Documento já cadastrado"));

                    EntidadeModel l = _mapper.Map<EntidadeModel>(entidade);
                    await _service.Adiciona(_mapper.Map<EntidadeModel>(entidade));

                    return Ok(new BCAPIDefaultResponse<EntidadeCreateDTO>(System.Net.HttpStatusCode.OK, _mapper.Map<EntidadeCreateDTO>(entidade)));
                }
                else
                    return BadRequest(new BCAPIDefaultResponse<EntidadeCreateDTO>(System.Net.HttpStatusCode.BadRequest, "Dados inválidos"));

            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return StatusCode(500, new BCAPIDefaultResponse<EntidadeCreateDTO>(System.Net.HttpStatusCode.InternalServerError, ex));
            }
        }

        /// <summary>
        /// Busca lançamentos diários
        /// </summary>
        /// <param name="id">Id (GUID) da entidade a ser atalizada</param>
        /// <param name="entidade">Entidade com os novos valores</param>
        /// <response code="204">Retorna sucesso</response>
        /// <response code="400">Caso algum dado esteja inválido</response>
        /// <response code="500">Em caso de erro catastrófico</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(BCAPIDefaultResponse<object>), 400)]
        [ProducesResponseType(typeof(BCAPIDefaultResponse<object>), 500)]
        public async Task<ActionResult<BCAPIDefaultResponse<EntidadeUpdateDTO>>> AtualizaEntidade(Guid id, [FromBody] EntidadeUpdateDTO entidade)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var original = await _service.BuscaEntidade(id);

                    if (original == null)
                        return BadRequest(new BCAPIDefaultResponse<EntidadeUpdateDTO>(System.Net.HttpStatusCode.BadRequest, "Dados inválidos"));

                    if (original.IdEntidade != entidade.IdEntidade)
                        return BadRequest(new BCAPIDefaultResponse<EntidadeUpdateDTO>(System.Net.HttpStatusCode.BadRequest, "Dados inválidos"));

                    _mapper.Map(entidade, original);
                    await _service.Atualiza(original);

                    return Ok(new BCAPIDefaultResponse<EntidadeUpdateDTO>(System.Net.HttpStatusCode.NoContent, _mapper.Map<EntidadeUpdateDTO>(entidade)));
                }
                else
                    return BadRequest(new BCAPIDefaultResponse<EntidadeUpdateDTO>(System.Net.HttpStatusCode.BadRequest, "Dados inválidos"));
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return StatusCode(500, new BCAPIDefaultResponse<EntidadeReadDTO>(System.Net.HttpStatusCode.InternalServerError, ex));
            }
        }

        /// <summary>
        /// Deleta entidade
        /// </summary>
        /// <param name="id">Id (GUID) da entidade</param>
        /// <response code="204">Retorna sucesso</response>
        /// <response code="400">Caso algum dado esteja inválido</response>
        /// <response code="500">Em caso de erro catastrófico</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(BCAPIDefaultResponse<object>), 400)]
        [ProducesResponseType(typeof(BCAPIDefaultResponse<object>), 500)]
        public async Task<ActionResult<BCAPIDefaultResponse<EntidadeReadDTO>>> RemoveEntidade(Guid id)
        {
            try
            {
                if (!id.Equals(Guid.Empty))
                {
                    var original = await _service.BuscaEntidade(id);

                    if (original == null)
                        return BadRequest(new BCAPIDefaultResponse<EntidadeReadDTO>(System.Net.HttpStatusCode.NotFound, "Dados inválidos"));

                    await _service.Remove(original);

                    return Ok(new BCAPIDefaultResponse<EntidadeReadDTO>(System.Net.HttpStatusCode.NoContent, result: null));
                }
                else
                    return BadRequest(new BCAPIDefaultResponse<EntidadeReadDTO>(System.Net.HttpStatusCode.BadRequest, "Dados inválidos"));
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return StatusCode(500, new BCAPIDefaultResponse<EntidadeReadDTO>(System.Net.HttpStatusCode.InternalServerError, ex));
            }
        }
    }
}
