using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Mediator.Commands.Nation;
using MediatR;

namespace ChampManReborn.Mediator.Handlers.Nation;

public class UpdateNationCommandHandler(INationService nationService) : IRequestHandler<UpdateNationCommand, bool>
{
    public async Task<bool> Handle(UpdateNationCommand request, CancellationToken cancellationToken)
    {
        var nation = await nationService.GetNationByIdAsync(request.Id);

        nation.Name = request.UpdateNationDto.Name;
        nation.Continent = request.UpdateNationDto.Continent;
        nation.Reputation = request.UpdateNationDto.Reputation;

        await nationService.UpdateNationAsync(nation);

        return true;
    }
}