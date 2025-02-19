using MediatR;

namespace ChampManReborn.Mediator.Commands.Nation;

public record DeleteNationCommand(Guid Id) : IRequest<bool>;