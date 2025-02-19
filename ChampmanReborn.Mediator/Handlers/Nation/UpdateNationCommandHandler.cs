using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Mediator.Commands.Nation;
using MediatR;

namespace ChampManReborn.Mediator.Handlers.Nation;

public class UpdateNationCommandHandler(INationService nationService) : IRequestHandler<UpdateNationCommand, bool>
{
    public async Task<bool> Handle(UpdateNationCommand request, CancellationToken cancellationToken)
    {
        var nation = await nationService.GetNationByIdAsync(request.Id);

        if (nation == null)
            return false;

        nation.Name = request.Name;
        nation.Continent = Convert.ToInt32(request.Continent);
        nation.Reputation = request.Reputation;

        await nationService.UpdateNationAsync(nation);

        return true;
    }
}