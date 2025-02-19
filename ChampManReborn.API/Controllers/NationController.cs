using ChampManReborn.API.DTOs;
using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ChampManReborn.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NationController(INationService nationService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllNations()
    {
        var nations = await nationService.GetAllNationsAsync();

        var nationDtos = nations
            .Where(nation => nation != null)
            .Select(nation => new NationDto
            {
                Id = nation.Id,
                Name = nation.Name,
                Continent = nation.Continent,
                Reputation = nation.Reputation
            });

        return Ok(nationDtos);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetNationById(Guid id)
    {
        var nation = await nationService.GetNationByIdAsync(id);

        if (nation == null)
            return NotFound();

        var nationDto = new NationDto
        {
            Id = nation.Id,
            Name = nation.Name,
            Continent = nation.Continent,
            Reputation = nation.Reputation
        };

        return Ok(nationDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateNation(CreateNationDto createNationDto)
    {
        var nation = new Nation
        {
            Name = createNationDto.Name,
            Continent = createNationDto.Continent,
            Reputation = createNationDto.Reputation
        };

        await nationService.AddNationAsync(nation);
        return CreatedAtAction(nameof(GetNationById), new { id = nation.Id }, nation);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateNation(Guid id, CreateNationDto updateNationDto)
    {
        var nation = await nationService.GetNationByIdAsync(id);

        if (nation == null)
            return NotFound();

        nation.Name = updateNationDto.Name;
        nation.Continent = updateNationDto.Continent;
        nation.Reputation = updateNationDto.Reputation;

        await nationService.UpdateNationAsync(nation);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteNation(Guid id)
    {
        var nation = await nationService.GetNationByIdAsync(id);

        if (nation == null)
            return NotFound();

        await nationService.DeleteNationAsync(id);
        return NoContent();
    }
}