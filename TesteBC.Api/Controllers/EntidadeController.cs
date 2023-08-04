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
    public class EntidadeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEntidadeService _service;

        public EntidadeController(IMapper mapper, IEntidadeService service)
        {
            _mapper = mapper;
            _service = service;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BCAPIDefaultResponse<EntidadeUpdateDTO>>> AtualizaEntidade(Guid id, [FromBody] EntidadeUpdateDTO entidade)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var original = await _service.BuscaEntidade(id);

                    if (original == null)
                        return BadRequest(new BCAPIDefaultResponse<EntidadeUpdateDTO>(System.Net.HttpStatusCode.BadRequest, "Dados inválidos"));

                    if (original.idEntidade != entidade.idEntidade)
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

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
