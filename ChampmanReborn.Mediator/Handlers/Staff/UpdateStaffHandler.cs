using MediatR;
using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Mediator.Commands.Staff;

namespace ChampManReborn.Mediator.Handlers.Staff;

public class UpdateStaffHandler(IStaffService staffService) : IRequestHandler<UpdateStaffCommand>
{
    public async Task<Unit> Handle(UpdateStaffCommand request, CancellationToken cancellationToken)
    {
        var staff = await staffService.GetStaffByIdAsync(request.Id);

        if (staff == null) throw new KeyNotFoundException();

        staff.FirstName = request.CreateStaffDto.FirstName;
        staff.LastName = request.CreateStaffDto.LastName;

        await staffService.UpdateStaffAsync(staff);

        return Unit.Value;
    }
}