using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChampManReborn.Application.Contracts.DTOs;
using ChampManReborn.Mediator.Commands.Staff;
using ChampManReborn.Mediator.Queries.Staff;

namespace ChampManReborn.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StaffController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllStaff()
    {
        var staffDtos = await mediator.Send(new GetAllStaffQuery());
        return Ok(staffDtos);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetStaffById(Guid id)
    {
        var staffDto = await mediator.Send(new GetStaffByIdQuery(id));
        return Ok(staffDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateStaff(CreateStaffDto createStaffDto)
    {
        var command = new CreateStaffCommand(
            createStaffDto.FirstName, 
            createStaffDto.SecondName, 
            createStaffDto.CommonName);

        var id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetStaffById), new { id }, null);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateStaff(Guid id, CreateStaffDto updateStaffDto)
    {
        var command = new UpdateStaffCommand(id,
            updateStaffDto.FirstName, 
            updateStaffDto.SecondName, 
            updateStaffDto.CommonName);

        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteStaff(Guid id)
    {
        await mediator.Send(new DeleteStaffCommand(id));
        return NoContent();
    }
}