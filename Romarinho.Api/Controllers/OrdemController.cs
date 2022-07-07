using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Romarinho.Api.DTOs;
using Romarinho.Domain.Model;
using Romarinho.Domain.Services;

namespace Romarinho.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdemController : ControllerBase
{
    private readonly ILogger<OrdemController> _logger;
    private readonly IOrdemService _service;
    private readonly IMapper _mapper;

    public OrdemController(ILogger<OrdemController> logger, IOrdemService service, IMapper mapper)
    {
        _logger = logger;
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public ActionResult<OrdemDTO> Get(int id)
    {
        try
        {
            return Ok(_mapper.Map<OrdemDTO>(_service.PegarPorId(id)));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }

    [HttpPost]
    public ActionResult Post([FromBody]OrdemDTO ordem)
    {
        try
        {
            _service.Cadastrar(_mapper.Map<Ordem>(ordem));
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }

    [HttpPut]
    public ActionResult Put([FromBody]OrdemDTO ordem)
    {
        try
        {
            _service.Editar(_mapper.Map<Ordem>(ordem));
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
    public ActionResult<IEnumerable<OrdemDTO>> GetByUser(int idUsuario)
    {
        try
        {
            var ordens = _service.PegarPorIdUsuario(idUsuario).ToList();

            var dtos = new List<OrdemDTO>();
            foreach (var ordem in ordens)
            {
                dtos.Add(_mapper.Map<OrdemDTO>(ordem));
            }
            
            return Ok(dtos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500);
        }
    }
}

