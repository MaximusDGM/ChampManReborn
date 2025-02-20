using MediatR;

namespace ChampManReborn.Mediator.Commands.Staff;

public class DeleteStaffCommand(Guid id) : IRequest
{
    public Guid Id { get; set; } = id;
}