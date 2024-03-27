
using AutoMapper;
using DietaInteligente.Domain.Repositories;
using MediatR;

namespace DietaInteligente.Application.Commands.Dietas.Delete;

public class DeleteDietaCommandHandler : IRequestHandler<DeleteDietaCommand, CommandResult>
{
    private readonly IMapper _mapper;
    private readonly IDietaRepository _dietaRepository;

    public DeleteDietaCommandHandler(IMapper mapper, IDietaRepository dietaRepository)
    {
        _mapper = mapper;
        _dietaRepository = dietaRepository;
    }

    public async Task<CommandResult> Handle(DeleteDietaCommand request, CancellationToken cancellationToken)
    {
        var dieta = await _dietaRepository.BuscarDietaAsync(request.Id);
        var success = await _dietaRepository.DeletarDietaAsync(dieta);

        if (success)
        {
            return CommandResult.SuccessResult("Dieta deletada com sucesso!");
        }
        return CommandResult.FailureResult(new[] {"Falha ao deletar dieta!"});
    }
}
