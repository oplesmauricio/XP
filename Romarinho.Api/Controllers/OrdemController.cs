using Microsoft.AspNetCore.Mvc;
using Romarinho.Domain.Model;
using Romarinho.Domain.Services;

namespace Romarinho.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdemController : ControllerBase
{
    private readonly ILogger<OrdemController> _logger;
    private readonly IOrdemService _service;

    public OrdemController(ILogger<OrdemController> logger, IOrdemService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("{id}")]
    public ActionResult<Ordem> Get(int id)
    {
        try
        {
            return Ok(_service.PegarPorId(id));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }

    [HttpPost]
    public ActionResult Post([FromBody]Ordem ordem)
    {
        try
        {
            _service.Cadastrar(ordem);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }

    [HttpPut]
    public ActionResult Put([FromBody] Ordem ordem)
    {
        try
        {
            _service.Editar(ordem);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        try
        {
            _service.Excluir(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }

    [HttpGet("GetByUser/{idUsuario}")]
    public ActionResult<IEnumerable<Ordem>> GetByUser(int idUsuario)
    {
        try
        {
            return Ok(_service.PegarPorIdUsuario(idUsuario));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
}

