
using AutoMapper;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Commands.Dietas.Update;

public class UpdateDietaCommandHandler : IRequestHandler<UpdateDietaCommand, CommandResult>
{
    private readonly IMapper _mapper;
    private readonly IDietaRepository _dietaRepository;

    public UpdateDietaCommandHandler(IMapper mapper, IDietaRepository dietaRepository)
    {
        _mapper = mapper;
        _dietaRepository = dietaRepository;
    }

    public async Task<CommandResult> Handle(UpdateDietaCommand request, CancellationToken cancellationToken)
    {
        var dieta = _mapper.Map<Dieta>(request.DietaAlimento);
        var success = await _dietaRepository.AtualizarDietaAsync(dieta);

        if (success)
        {
            return CommandResult.SuccessResult("Sucesso ao atualizar dieta!");
        }
        return CommandResult.FailureResult(new[] { "Falha ao atualizar dieta!" });
    }
}
