using MediatR;
using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Application.Contracts.DTOs;
using ChampManReborn.Mediator.Queries.Player;

namespace ChampManReborn.Mediator.Handlers.Player;

public class GetPlayerByIdHandler(IPlayerService playerService) : IRequestHandler<GetPlayerByIdQuery, PlayerDto>
{
    public async Task<PlayerDto> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
    {
        var player = await playerService.GetPlayerByIdAsync(request.Id);

        return new PlayerDto
        {
            Id = player.Id,
            Name = player.Name,
            Age = player.Age
        };
    }
}