using MediatR;
using ChampManReborn.Application.Contracts.DTOs;

namespace ChampManReborn.Mediator.Queries.Staff;

public class GetStaffByIdQuery(Guid id) : IRequest<StaffDto>
{
    public Guid Id { get; set; } = id;
}