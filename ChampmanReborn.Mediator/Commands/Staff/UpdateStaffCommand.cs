using ChampManReborn.Application.Contracts.DTOs;
using MediatR;

namespace ChampManReborn.Mediator.Commands.Staff;

public class UpdateStaffCommand(Guid id, CreateStaffDto createStaffDto) : IRequest<Unit>
{
    public Guid Id { get; } = id;
    public CreateStaffDto CreateStaffDto { get; } = createStaffDto;
}