using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Mediator.Commands.Nation;
using MediatR;

namespace ChampManReborn.Mediator.Handlers.Nation;

public class CreateNationCommandHandler(INationService nationService) : IRequestHandler<CreateNationCommand, Guid>
{
    public async Task<Guid> Handle(CreateNationCommand request, CancellationToken cancellationToken)
    {
        var dto = request.CreateNationDto;

        var nation = new Domain.Entities.Nation
        {
            Name = dto.Name,
            Continent = dto.Continent,
            Reputation = dto.Reputation
        };

        await nationService.AddNationAsync(nation);
        
        return nation.Id;
    }
}