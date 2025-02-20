using MediatR;
using ChampManReborn.Application.Contracts.DTOs;

namespace ChampManReborn.Mediator.Queries.Staff;

public class GetAllStaffQuery : IRequest<IEnumerable<StaffDto>> { }