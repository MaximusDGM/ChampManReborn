using ChampManReborn.Application.Contracts.DTOs;
using MediatR;

namespace ChampManReborn.Mediator.Queries.Nation;

public record GetNationByIdQuery(Guid Id) : IRequest<NationDto>;