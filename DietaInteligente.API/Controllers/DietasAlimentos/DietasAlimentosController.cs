using DietaInteligente.Application.InputModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DietaInteligente.Application.Commands.DietasAlimentos.Associate;
using DietaInteligente.Application.Commands.DietasAlimentos.Disassociate;
using DietaInteligente.Application.Queries.DietasAlimentos.GetAll;
using DietaInteligente.Application.Queries.DietasAlimentos.GetById;

namespace DietaInteligente.Api.Controllers;

[ApiController]
[Route("api/dietaalimentos")]
public class DietaAlimentosController : ControllerBase
{
    private readonly IMediator _mediator;

    public DietaAlimentosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllDietasAlimentosQuery();
        var dietaAlimentos = await _mediator.Send(query);

        return Ok(dietaAlimentos);
    }

    [HttpGet("{dietaId}")]
    public async Task<IActionResult> GetByDietaId(int dietaId)
    {
        var query = new GetDietaAlimentoByIdQuery(dietaId);
        var alimentos = await _mediator.Send(query);
        if (alimentos == null)
            return NotFound();

        return Ok(alimentos);
    }

    [HttpPost("associate")]
    public async Task<IActionResult> Associate([FromBody] DietaAlimentoInputModel inputModel)
    {
        var command = new AssociateDietaAlimentoCommand(inputModel.DietaId, inputModel.AlimentoId, inputModel.QuantidadeGramas);
        var result = await _mediator.Send(command);
        if (!result.Success)
            return BadRequest(result.Errors);

        return Ok("Sucesso ao associar dieta e alimento");
    }

    [HttpDelete("disassociate/{dietaId}/{alimentoId}")]
    public async Task<IActionResult> Disassociate(int dietaId, int alimentoId)
    {
        var command = new DisassociateDietaAlimentoCommand(dietaId, alimentoId);
        var result = await _mediator.Send(command);
        if (!result.Success)
            return BadRequest(result.Errors);

        return Ok("Sucesso ao desassociar dieta e alimento");
    }
}
