using ChampManReborn.Application.Contracts.DTOs;
using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Mediator.Queries.Nation;
using MediatR;

namespace ChampManReborn.Mediator.Handlers.Nation;

public class GetAllNationsQueryHandler(INationService nationService)
    : IRequestHandler<GetAllNationsQuery, IEnumerable<NationDto>>
{
    public async Task<IEnumerable<NationDto>> Handle(GetAllNationsQuery request, CancellationToken cancellationToken)
    {
        var nations = await nationService.GetAllNationsAsync();
            
        return nations.Select(nation => new NationDto
        {
            Id = nation.Id,
            Name = nation.Name,
            Continent = nation.Continent,
            Reputation = nation.Reputation
        });
    }
}