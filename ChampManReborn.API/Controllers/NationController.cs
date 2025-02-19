using ChampManReborn.Application.Contracts.DTOs;
using ChampManReborn.Mediator.Commands.Nation;
using ChampManReborn.Mediator.Queries.Nation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChampManReborn.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NationController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllNations()
    {
        var nationDtos = await mediator.Send(new GetAllNationsQuery());

        return Ok(nationDtos);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetNationById(Guid id)
    {
        var nationDto = await mediator.Send(new GetNationByIdQuery(id));

        return Ok(nationDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateNation(CreateNationDto createNationDto)
    {
        var nationId = await mediator.Send(new CreateNationCommand(createNationDto));

        return CreatedAtAction(nameof(GetNationById), new { id = nationId }, createNationDto);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateNation(Guid id, CreateNationDto updateNationDto)
    {
        var success = await mediator.Send(new UpdateNationCommand(id, updateNationDto));

        if (!success)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteNation(Guid id)
    {
        var success = await mediator.Send(new DeleteNationCommand(id));

        if (!success)
            return NotFound();

        return NoContent();
    }
}