using ChampManReborn.Application.Contracts.DTOs;
using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ChampManReborn.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeamController(ITeamService teamService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllTeams()
    {
        var teams = await teamService.GetAllTeamsAsync();

        var teamDtos = teams
            .Where(team => team != null)
            .Select(team =>
            {
                if (team != null)
                    return new TeamDto
                    {
                        Id = team.Id,
                        Name = team.Name,
                        Stadium = team.Stadium
                    };
                return null;
            });

        return Ok(teamDtos);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetTeamById(Guid id)
    {
        var team = await teamService.GetTeamByIdAsync(id);

        if (team == null)
            return NotFound();

        var teamDto = new TeamDto
        {
            Id = team.Id,
            Name = team.Name,
            Stadium = team.Stadium
        };

        return Ok(teamDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTeam(CreateTeamDto createTeamDto)
    {
        var team = new Team
        {
            Name = createTeamDto.Name,
            Stadium = createTeamDto.Stadium
        };

        await teamService.AddTeamAsync(team);
        return CreatedAtAction(nameof(GetTeamById), new { id = team.Id }, team);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateTeam(Guid id, CreateTeamDto updateTeamDto)
    {
        var team = await teamService.GetTeamByIdAsync(id);

        if (team == null)
            return NotFound();

        team.Name = updateTeamDto.Name;
        team.Stadium = updateTeamDto.Stadium;

        await teamService.UpdateTeamAsync(team);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteTeam(Guid id)
    {
        var team = await teamService.GetTeamByIdAsync(id);

        if (team == null)
            return NotFound();

        await teamService.DeleteTeamAsync(id);
        return NoContent();
    }
}