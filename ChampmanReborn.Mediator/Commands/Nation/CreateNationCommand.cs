using ChampManReborn.Application.Contracts.DTOs;
using MediatR;

namespace ChampManReborn.Mediator.Commands.Nation;

public record CreateNationCommand(CreateNationDto CreateNationDto) : IRequest<Guid>;