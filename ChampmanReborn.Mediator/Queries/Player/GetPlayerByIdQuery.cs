using MediatR;
using ChampManReborn.Application.Contracts.DTOs;

namespace ChampManReborn.Mediator.Queries.Player;

public class GetPlayerByIdQuery(Guid id) : IRequest<PlayerDto>
{
    public Guid Id { get; set; } = id;
}