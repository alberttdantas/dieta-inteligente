using DietaInteligente.Application.Commands.GruposAlimentares.Create;
using DietaInteligente.Application.Commands.GruposAlimentares.Delete;
using DietaInteligente.Application.Commands.GruposAlimentares.Update;
using DietaInteligente.Application.InputModels;
using DietaInteligente.Application.Queries.GruposAlimentares.GetAll;
using DietaInteligente.Application.Queries.GruposAlimentares.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DietaInteligente.API.Controllers.GruposAlimentares;

[ApiController]
[Route("api/grupoalimentar")]
public class GruposAlimentaresController : ControllerBase
{
    private readonly IMediator _mediator;

    public GruposAlimentaresController(IMediator mediator) : base()
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllGruposAlimentaresQuery();
        var grupoAlimentar = await _mediator.Send(query);

        return Ok(grupoAlimentar);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id) 
    {
        var query = new GetGrupoAlimentarByIdQuery(id);
        var grupoAlimentar = await _mediator.Send(query);
        if (grupoAlimentar == null)
            return NotFound($"Nenhum grupo alimentar encontrado com o ID {id}.");

        return Ok(grupoAlimentar);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] GrupoAlimentarInputModel inputModel)
    {
        var command = new CreateGrupoAlimentarCommand(inputModel);
        var result = await _mediator.Send(command);
        if (!result.Success)
            return BadRequest(result.Errors);

        return Ok("Grupo alimentar criado");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] GrupoAlimentarInputModel inputModel)
    {
        var command = new UpdateGrupoAlimentarCommand(inputModel);
        var result = await _mediator.Send(command);
        if (!result.Success)
            return BadRequest(result.Errors);

        return Ok("Grupo alimentar atualizado");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteGrupoAlimentarCommand(id);
        var result = await _mediator.Send(command);
        if (!result.Success)
            return BadRequest(result.Errors);

        return Ok("Grupo alimentar deletado");
    }
}
