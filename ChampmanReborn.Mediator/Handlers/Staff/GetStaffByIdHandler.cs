using MediatR;
using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Application.Contracts.DTOs;
using ChampManReborn.Mediator.Queries.Staff;

namespace ChampManReborn.Mediator.Handlers.Staff;

public class GetStaffByIdHandler(IStaffService staffService) : IRequestHandler<GetStaffByIdQuery, StaffDto>
{
    public async Task<StaffDto> Handle(GetStaffByIdQuery request, CancellationToken cancellationToken)
    {
        var staff = await staffService.GetStaffByIdAsync(request.Id);

        return new StaffDto
        {
            Id = staff.Id,
            FirstName = staff.FirstName,
            LastName = staff.LastName,
            Age = staff.Age
        };
    }
}