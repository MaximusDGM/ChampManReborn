using MediatR;
using ChampManReborn.Application.Contracts.DTOs;

namespace ChampManReborn.Mediator.Queries.Player;

public class GetAllPlayersQuery : IRequest<IEnumerable<PlayerDto>> { }