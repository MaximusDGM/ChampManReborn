using ChampManReborn.Application.Contracts.DTOs;
using MediatR;

namespace ChampManReborn.Mediator.Commands.Staff;

public class CreateStaffCommand(CreateStaffDto createStaffDto) : IRequest<Guid>
{
    public CreateStaffDto createStaffDto = createStaffDto;
}