using ChampManReborn.Application.Contracts.DTOs;
using MediatR;

namespace ChampManReborn.Mediator.Commands.Nation;

public record UpdateNationCommand(Guid Id, CreateNationDto UpdateNationDto) : IRequest<bool>;