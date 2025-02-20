using MediatR;
using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Mediator.Commands.Player;

namespace ChampManReborn.Mediator.Handlers.Player;

public class CreatePlayerHandler(IPlayerService playerService) : IRequestHandler<CreatePlayerCommand, Guid>
{
    public async Task<Guid> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
    {
        var player = new Domain.Entities.Player
        {
            Name = request.Name,
            Age = request.Age
        };

        await playerService.AddPlayerAsync(player);
        return player.Id;
    }
}