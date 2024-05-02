using DietaInteligente.Application.Commands.InformacoesNutricionais.Create;
using DietaInteligente.Application.Commands.InformacoesNutricionais.Delete;
using DietaInteligente.Application.Commands.InformacoesNutricionais.Update;
using DietaInteligente.Application.InputModels;
using DietaInteligente.Application.Queries.InformacoesNutricionais.GetAll;
using DietaInteligente.Application.Queries.InformacoesNutricionais.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DietaInteligente.API.Controllers.InformacoesNutricionais;

[ApiController]
[Route("api/informacaonutricional")]
public class InformacoesNutricionaisController : ControllerBase
{
    private readonly IMediator _mediator;

    public InformacoesNutricionaisController(IMediator mediator) : base()
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllInformacoesNutricionaisQuery();
        var informacaoNutricional = await _mediator.Send(query);

        return Ok(informacaoNutricional);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetInformacaoNutricionalByIdQuery(id);
        var informacaoNutricional = await _mediator.Send(query);
        if (informacaoNutricional == null)
            return NotFound($"Nenhuma informação nutricional encontrada com o ID {id}.");

        return Ok(informacaoNutricional);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] InformacaoNutricionalInputModel inputModel)
    {
        var command = new CreateInformacoesNutricionaisCommand(inputModel);
        var result = await _mediator.Send(command);
        if (!result.Success)
            return BadRequest(result.Errors);

        return Ok("Informação nutricional criada");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] InformacaoNutricionalInputModel inputModel)
    {
        var command = new UpdateInformacoesNutricionaisCommand(inputModel);
        var result = await _mediator.Send(command);
        if (!result.Success)
            return BadRequest(result.Errors);

        return Ok("Informacão nutricional atualizada");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteInformacoesNutricionaisCommand(id);
        var result = await _mediator.Send(command);
        if (!result.Success)
            return BadRequest(result.Errors);

        return Ok("Informação nutricional deletada");
    }
}
