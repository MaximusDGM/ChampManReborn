using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Mediator.Commands.Nation;
using MediatR;

namespace ChampManReborn.Mediator.Handlers.Nation;

public class DeleteNationCommandHandler(INationService nationService) : IRequestHandler<DeleteNationCommand, bool>
{
    public async Task<bool> Handle(DeleteNationCommand request, CancellationToken cancellationToken)
    {
        var nation = await nationService.GetNationByIdAsync(request.Id);

        if (nation == null)
            return false;

        await nationService.DeleteNationAsync(request.Id);
        return true;
    }
}