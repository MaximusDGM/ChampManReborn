using MediatR;
using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Application.Contracts.DTOs;
using ChampManReborn.Mediator.Queries.Player;

namespace ChampManReborn.Mediator.Handlers.Player;

public class GetAllPlayersHandler(IPlayerService playerService)
    : IRequestHandler<GetAllPlayersQuery, IEnumerable<PlayerDto>>
{
    public async Task<IEnumerable<PlayerDto>> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
    {
        var players = await playerService.GetAllPlayersAsync();
        return players
            .Where(player => player != null)
            .Select(player => new PlayerDto
            {
                Id = player.Id,
                Name = player.Name,
                Age = player.Age
            });
    }
}