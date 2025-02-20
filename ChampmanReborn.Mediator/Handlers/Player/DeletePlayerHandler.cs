using MediatR;
using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Mediator.Commands.Player;

namespace ChampManReborn.Mediator.Handlers.Player;

public class DeletePlayerHandler(IPlayerService playerService) : IRequestHandler<DeletePlayerCommand>
{
    public async Task<Unit> Handle(DeletePlayerCommand request, CancellationToken cancellationToken)
    {
        var player = await playerService.GetPlayerByIdAsync(request.Id);
        if (player == null) throw new KeyNotFoundException();

        await playerService.DeletePlayerAsync(request.Id);

        return Unit.Value;
    }
}