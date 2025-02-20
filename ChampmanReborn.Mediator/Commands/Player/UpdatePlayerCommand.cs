using MediatR;

namespace ChampManReborn.Mediator.Commands.Player;

public class UpdatePlayerCommand : IRequest
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int Age { get; set; }
}