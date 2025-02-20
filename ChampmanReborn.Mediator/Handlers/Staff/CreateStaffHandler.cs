using MediatR;
using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Mediator.Commands.Staff;

namespace ChampManReborn.Mediator.Handlers.Staff;

public class CreateStaffHandler(IStaffService staffService) : IRequestHandler<CreateStaffCommand, Guid>
{
    public async Task<Guid> Handle(CreateStaffCommand request, CancellationToken cancellationToken)
    {
        var staff = new Domain.Entities.Staff
        {
            FirstName = request.FirstName,
            SecondName = request.SecondName,
            CommonName = request.CommonName,
            Name = request.FirstName + " " + request.SecondName
        };

        await staffService.AddStaffAsync(staff);
        return staff.Id;
    }
}