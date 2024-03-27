
using AutoMapper;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Commands.Alimentos.Update;

public class UpdateAlimentoCommandHandler : IRequestHandler<UpdateAlimentoCommand, CommandResult>
{
    private readonly IMapper _mapper;
    private readonly IAlimentoRepository _alimentoRepository;

    public UpdateAlimentoCommandHandler(IMapper mapper, IAlimentoRepository alimentoRepository)
    {
        _mapper = mapper;
        _alimentoRepository = alimentoRepository;
    }

    public async Task<CommandResult> Handle(UpdateAlimentoCommand request, CancellationToken cancellationToken)
    {
        var alimento = _mapper.Map<Alimento>(request.AlimentoInput);
        var success = await _alimentoRepository.AtualizarAlimento(alimento);

        if(success)
        {
            return CommandResult.SuccessResult("Alimento atualizado com sucesso");
        }
        return CommandResult.FailureResult(new[] { "Falha ao atualizar alimento" });
    }
}
