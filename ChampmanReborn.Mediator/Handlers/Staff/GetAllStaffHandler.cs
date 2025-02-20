using MediatR;
using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Application.Contracts.DTOs;
using ChampManReborn.Mediator.Queries.Staff;

namespace ChampManReborn.Mediator.Handlers.Staff;

public class GetAllStaffHandler(IStaffService staffService) : IRequestHandler<GetAllStaffQuery, IEnumerable<StaffDto>>
{
    public async Task<IEnumerable<StaffDto>> Handle(GetAllStaffQuery request, CancellationToken cancellationToken)
    {
        var staffList = await staffService.GetAllStaffAsync();

        return staffList
            .Select(staff => new StaffDto
            {
                Id = staff.Id,
                FirstName = staff.FirstName,
                LastName = staff.LastName,
                Age = staff.Age
            });
    }
}