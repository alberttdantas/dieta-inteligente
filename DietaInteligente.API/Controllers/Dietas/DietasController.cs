using DietaInteligente.Application.Commands.Dietas.Create;
using DietaInteligente.Application.Commands.Dietas.Delete;
using DietaInteligente.Application.Commands.Dietas.Update;
using DietaInteligente.Application.InputModels;
using DietaInteligente.Application.Queries.Dietas.GetAll;
using DietaInteligente.Application.Queries.Dietas.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DietaInteligente.API.Controllers.Dietas;

[ApiController]
[Route("api/dietas")]
public class DietasController : ControllerBase
{
    private readonly IMediator _mediator;

    public DietasController(IMediator mediator) : base()
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllDietasQuery();
        var dietas = await _mediator.Send(query);
        return Ok(dietas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetDietaByIdQuery(id);
        var dieta = await _mediator.Send(query);
        if (dieta == null)
            return NotFound();

        return Ok(dieta);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] DietaInputModel inputModel)
    {
        if (inputModel == null)
        {
            return BadRequest("O modelo de entrada não pode ser nulo.");
        }

        var command = new CreateDietaCommand(inputModel);
        var result = await _mediator.Send(command);
        if (!result.Success)
            return BadRequest(result.Errors);

        return Ok(result.Message);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] DietaInputModel inputModel)
    {
        var command = new UpdateDietaCommand(inputModel);
        var result = await _mediator.Send(command);
        if (!result.Success)
            return BadRequest(result.Errors);
        return Ok("Dieta atualizada");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteDietaCommand(id);
        var result = await _mediator.Send(command);
        if (!result.Success)
            return BadRequest(result.Errors);
        return Ok("Dieta deletada");
    }
}
