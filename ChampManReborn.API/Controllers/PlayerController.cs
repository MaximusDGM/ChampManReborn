using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChampManReborn.Application.Contracts.DTOs;
using ChampManReborn.Mediator.Commands.Player;
using ChampManReborn.Mediator.Queries.Player;

namespace ChampManReborn.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayerController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllPlayers()
    {
        var playerDtos = await mediator.Send(new GetAllPlayersQuery());
        return Ok(playerDtos);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetPlayerById(Guid id)
    {
        var playerDto = await mediator.Send(new GetPlayerByIdQuery(id));
        return Ok(playerDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePlayer(CreatePlayerDto createPlayerDto)
    {
        var command = new CreatePlayerCommand
        {
            Name = createPlayerDto.Name,
            Age = createPlayerDto.Age
        };

        var id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetPlayerById), new { id }, null);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdatePlayer(Guid id, CreatePlayerDto updatePlayerDto)
    {
        var command = new UpdatePlayerCommand
        {
            Id = id,
            FirstName = updatePlayerDto.Name,
            Age = updatePlayerDto.Age
        };

        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeletePlayer(Guid id)
    {
        await mediator.Send(new DeletePlayerCommand(id));
        return NoContent();
    }
}