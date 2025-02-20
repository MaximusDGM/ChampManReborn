using MediatR;
using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Mediator.Commands.Player;

namespace ChampManReborn.Mediator.Handlers.Player;

public class UpdatePlayerHandler(IPlayerService playerService) : IRequestHandler<UpdatePlayerCommand>
{
    public async Task<Unit> Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
    {
        var player = await playerService.GetPlayerByIdAsync(request.Id);
        if (player == null) throw new KeyNotFoundException();

        player.FirstName = request.FirstName;
        player.Age = request.Age;

        await playerService.UpdatePlayerAsync(player);

        return Unit.Value;
    }
}