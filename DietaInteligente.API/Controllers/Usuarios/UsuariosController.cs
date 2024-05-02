using DietaInteligente.Application.Commands.Usuarios.Create;
using DietaInteligente.Application.Commands.Usuarios.Delete;
using DietaInteligente.Application.Commands.Usuarios.Update;
using DietaInteligente.Application.InputModels;
using DietaInteligente.Application.Queries.Usuarios.GetAll;
using DietaInteligente.Application.Queries.Usuarios.GetById;
using DietaInteligente.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DietaInteligente.API.Controllers.Usuarios;
[ApiController]
[Route("api/usuario")]
public class UsuariosController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsuariosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllUsuariosQuery();
        var usuarios = await _mediator.Send(query);

        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id) 
    {
        var query = new GetUsuarioByIdQuery(id);
        var usuario = await _mediator.Send(query);
        if (usuario == null)
            return NotFound($"Nenhuma usuario encontrado com o ID {id}.");

        return Ok(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UsuarioInputModel inputModel)
    {
        var command = new CreateUsuarioCommand(inputModel);
        var result = await _mediator.Send(command);
        if (!result.Success)
            return BadRequest(result.Errors);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] UsuarioInputModel inputModel)
    {
        var command = new UpdateUsuarioCommand(inputModel);
        var result = await _mediator.Send(command);
        if (!result.Success)
            return BadRequest(result.Errors);

        return Ok("Usuario atualizado");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteUsuarioCommand(id);
        var result = await _mediator.Send(command);
        if (!result.Success)
            return BadRequest(result.Errors);

        return Ok("Usuario deletado");
    }
}
