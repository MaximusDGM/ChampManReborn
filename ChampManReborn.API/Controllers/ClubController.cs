using ChampManReborn.Application.Contracts.DTOs;
using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ChampManReborn.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClubController(IClubService clubService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllClubs()
    {
        var clubs = await clubService.GetAllClubsAsync();

        var clubDtos = clubs
            .Where(club => club != null)
            .Select(club =>
            {
                if (club != null)
                    return new ClubDto
                    {
                        Id = club.Id,
                        Name = club.Name,
                        Stadium = club.Stadium
                    };
                return null;
            });

        return Ok(clubDtos);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetClubById(Guid id)
    {
        var club = await clubService.GetClubByIdAsync(id);

        if (club == null)
            return NotFound();

        var clubDto = new ClubDto
        {
            Id = club.Id,
            Name = club.Name,
            Stadium = club.Stadium
        };

        return Ok(clubDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateClub(CreateClubDto createClubDto)
    {
        var club = new Club
        {
            Name = createClubDto.Name,
            Stadium = createClubDto.Stadium
        };

        await clubService.AddClubAsync(club);
        return CreatedAtAction(nameof(GetClubById), new { id = club.Id }, club);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateClub(Guid id, CreateClubDto updateClubDto)
    {
        var club = await clubService.GetClubByIdAsync(id);

        if (club == null)
            return NotFound();

        club.Name = updateClubDto.Name;
        club.Stadium = updateClubDto.Stadium;

        await clubService.UpdateClubAsync(club);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteClub(Guid id)
    {
        var club = await clubService.GetClubByIdAsync(id);

        if (club == null)
            return NotFound();

        await clubService.DeleteClubAsync(id);
        return NoContent();
    }
}