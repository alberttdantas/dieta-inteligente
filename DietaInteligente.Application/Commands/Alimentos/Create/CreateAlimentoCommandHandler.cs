
using AutoMapper;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Commands.Alimentos.Create;

public class CreateAlimentoCommandHandler : IRequestHandler<CreateAlimentoCommand, CommandResult>
{
    private readonly IMapper _mapper;
    private readonly IAlimentoRepository _alimentoRepository;

    public CreateAlimentoCommandHandler(IMapper mapper, IAlimentoRepository alimentoRepository)
    {
        _mapper = mapper;
        _alimentoRepository = alimentoRepository;
    }

    public async Task<CommandResult> Handle(CreateAlimentoCommand request, CancellationToken cancellationToken)
    {
        var alimento = _mapper.Map<Alimento>(request.AlimentoInput);
        var success = await _alimentoRepository.InserirAlimentoAsync(alimento);

        if (success)
        {
            return CommandResult.SuccessResult("ALimento inserido com sucesso.");
        }

        return CommandResult.FailureResult(new[] { "Falha ao inserir o alimento." });
    }
}
