
using DietaInteligente.Application.Commands.Alimentos.Create;
using DietaInteligente.Application.Commands.Alimentos.Delete;
using DietaInteligente.Application.Commands.Alimentos.Update;
using DietaInteligente.Application.InputModels;
using DietaInteligente.Application.Queries.Alimentos.GetAll;
using DietaInteligente.Application.Queries.Alimentos.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DietaInteligente.Api.Controllers;

[ApiController]
[Route("api/alimentos")]
public class AlimentosController : ControllerBase
{
    private readonly IMediator _mediator;

    public AlimentosController(IMediator mediator) : base()
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllAlimentosQuery();
        var alimentos = await _mediator.Send(query);

        return Ok(alimentos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetAlimentoByIdQuery(id);
        var alimento = await _mediator.Send(query);
        if (alimento == null)
            return NotFound($"Nenhum alimento encontrado com o ID {id}.");

        return Ok(alimento);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AlimentoInputModel inputModel)
    {
        var command = new CreateAlimentoCommand(inputModel);
        var result = await _mediator.Send(command);
        if (!result.Success)
            return BadRequest(result.Errors);

        return Ok("Alimento criado");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] AlimentoInputModel inputModel)
    {
        var command = new UpdateAlimentoCommand(inputModel);
        var result = await _mediator.Send(command);
        if (!result.Success)
            return BadRequest(result.Errors);

        return Ok("Alimento atualizado");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteAlimentoCommand(id);
        var result = await _mediator.Send(command);
        if (!result.Success)
            return BadRequest(result.Errors);

        return Ok("Alimento deleto");
    }
}
