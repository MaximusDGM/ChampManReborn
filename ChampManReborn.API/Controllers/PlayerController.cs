using ChampManReborn.API.DTOs;
using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ChampManReborn.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayerController : ControllerBase
{
    private readonly IPlayerService _playerService;

    public PlayerController(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    // Get all players
    [HttpGet]
    public async Task<IActionResult> GetAllPlayers()
    {
        var players = await _playerService.GetAllPlayersAsync();

        // Map Domain Model to DTO
        var playerDtos = players.Select(player => new PlayerDto
        {
            Id = player.Id,
            Name = player.Name,
            Age = player.Age,
        });

        return Ok(playerDtos);
    }

    // Get a player by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPlayerById(Guid id)
    {
        var player = await _playerService.GetPlayerByIdAsync(id);
        if (player == null)
        {
            return NotFound();
        }

        var playerDto = new PlayerDto
        {
            Id = player.Id,
            Name = player.Name,
            Age = player.Age,
        };

        return Ok(playerDto);
    }

    // Add a player
    [HttpPost]
    public async Task<IActionResult> CreatePlayer(CreatePlayerDto createPlayerDto)
    {
        var player = new Player
        {
            Name = createPlayerDto.Name,
            Age = createPlayerDto.Age,
        };

        await _playerService.AddPlayerAsync(player);
        return CreatedAtAction(nameof(GetPlayerById), new { id = player.Id }, player);
    }

    // Update a player
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePlayer(Guid id, CreatePlayerDto updatePlayerDto)
    {
        var player = await _playerService.GetPlayerByIdAsync(id);

        if (player == null) return NotFound();

        player.Name = updatePlayerDto.Name;
        player.Age = updatePlayerDto.Age;

        await _playerService.UpdatePlayerAsync(player);

        return NoContent();
    }

    // Delete a player
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlayer(Guid id)
    {
        var player = await _playerService.GetPlayerByIdAsync(id);

        if (player == null) return NotFound();

        await _playerService.DeletePlayerAsync(id);
        return NoContent();
    }
}
