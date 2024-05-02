using DietaInteligente.Application.Commands.RestricoesDieteticas.Associate;
using DietaInteligente.Application.Commands.RestricoesDieteticas.Disassociate;
using DietaInteligente.Application.InputModels;
using DietaInteligente.Application.Queries.RestricoesDieteticas.GetAll;
using DietaInteligente.Application.Queries.RestricoesDieteticas.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DietaInteligente.API.Controllers.RestricoesDieteticas;
[ApiController]
[Route("api/restricaodietetica")]
public class RestricoesDieteticasController : ControllerBase
{
    private readonly IMediator _mediator;

    public RestricoesDieteticasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllRestricoesDieteticasQuery();
        var restricoesDieteticas = await _mediator.Send(query);

        return Ok(restricoesDieteticas);
    }

    [HttpGet("{usuarioId}")]
    public async Task<IActionResult> GetByUsuarioId(int usuarioId)
    {
        var query = new GetRestricoesDieteticasByIdQuery(usuarioId);
        var restricaoDietetica = await _mediator.Send(query);
        if (restricaoDietetica == null)
            return NotFound($"Nenhuma restrição dietetica encontrado com o ID {usuarioId}.");

        return Ok(restricaoDietetica);
    }

    [HttpPost("associate")]
    public async Task<IActionResult> Associate([FromBody] RestricaoDieteticaInputModel inputModel)
    {
        var command = new AssociateRestricaoDieteticaCommand(inputModel.UsuarioId, inputModel.GrupoAlimentarId);
        var result = await _mediator.Send(command);
        if (!result.Success)
            return BadRequest(result.Errors);

        return Ok("Sucesso ao associar uma restrição a dieta");
    }

    [HttpDelete("disassociate/{usuarioId}/{grupoAlimentarId}")]
    public async Task<IActionResult> Disassociate(int usuarioId, int grupoAlimentarId)
    {
        var command = new DisassociateRestricaoDieteticaCommand(usuarioId, grupoAlimentarId);
        var result = await _mediator.Send(command);
        if (!result.Success)
            return BadRequest(result.Errors);

        return Ok("Sucesso ao desassociar restrição a dieta");
    }
}
