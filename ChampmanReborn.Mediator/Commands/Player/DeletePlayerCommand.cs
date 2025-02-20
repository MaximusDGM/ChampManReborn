using MediatR;

namespace ChampManReborn.Mediator.Commands.Player;

public class DeletePlayerCommand(Guid id) : IRequest
{
    public Guid Id { get; set; } = id;
}