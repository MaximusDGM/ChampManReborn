using MediatR;

namespace ChampManReborn.Mediator.Commands.Player;

public class CreatePlayerCommand : IRequest<Guid>
{
    public required string Name { get; set; }
    public int Age { get; set; }
}