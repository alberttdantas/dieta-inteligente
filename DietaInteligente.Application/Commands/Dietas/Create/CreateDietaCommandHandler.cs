
using AutoMapper;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Commands.Dietas.Create;

public class CreateDietaCommandHandler : IRequestHandler<CreateDietaCommand, CommandResult>
{
    private readonly IMapper _mapper;
    private readonly IDietaRepository _dietaRepository;

    public CreateDietaCommandHandler(IMapper mapper, IDietaRepository dietaRepository)
    {
        _mapper = mapper;
        _dietaRepository = dietaRepository;
    }

    public async Task<CommandResult> Handle(CreateDietaCommand request, CancellationToken cancellationToken)
    {
        var dieta = _mapper.Map<Dieta>(request.DietaInput);
        var success = await _dietaRepository.CriarDietaAsync(dieta);

        if (success)
        {
            return CommandResult.SuccessResult("Dieta criada com sucesso!");
        }
        return CommandResult.FailureResult(new[] { "Falha ao criar a dieta" });
    }
}
