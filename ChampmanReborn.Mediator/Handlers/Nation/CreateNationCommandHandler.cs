using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Mediator.Commands.Nation;
using MediatR;

namespace ChampManReborn.Mediator.Handlers.Nation;

public class CreateNationCommandHandler(INationService nationService) : IRequestHandler<CreateNationCommand, Guid>
{
    public async Task<Guid> Handle(CreateNationCommand request, CancellationToken cancellationToken)
    {
        var nation = new Domain.Entities.Nation
        {
            Name = request.Name,
            Continent = Convert.ToInt32(request.Continent),
            Reputation = request.Reputation
        };

        await nationService.AddNationAsync(nation);
        return nation.Id;
    }
}