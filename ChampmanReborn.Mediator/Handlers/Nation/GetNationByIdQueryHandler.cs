using ChampManReborn.Application.Contracts.DTOs;
using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Mediator.Queries.Nation;
using MediatR;

namespace ChampManReborn.Mediator.Handlers.Nation;

public class GetNationByIdQueryHandler(INationService nationService)
    : IRequestHandler<GetNationByIdQuery, NationDto>
{
    public async Task<NationDto> Handle(GetNationByIdQuery request, CancellationToken cancellationToken)
    {
        var nation = await nationService.GetNationByIdAsync(request.Id);

        if (nation == null)
            return null;

        return new NationDto
        {
            Id = nation.Id,
            Name = nation.Name,
            Continent = nation.Continent,
            Reputation = nation.Reputation
        };
    }
}