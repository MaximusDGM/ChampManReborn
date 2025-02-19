using ChampManReborn.API.DTOs;
using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ChampManReborn.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StaffController(IStaffService staffService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllStaff()
    {
        var staffList = await staffService.GetAllStaffAsync();

        var staffDtos = staffList
            .Select(staff => new StaffDto
            {
                Id = staff.Id,
                FirstName = staff.FirstName,
                SecondName = staff.SecondName,
                CommonName = staff.CommonName,
                Age = staff.DateOfBirth.HasValue
                    ? DateTime.UtcNow.Year - staff.DateOfBirth.Value.Year
                    : null
            });

        return Ok(staffDtos);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetStaffById(Guid id)
    {
        var staff = await staffService.GetStaffByIdAsync(id);

        if (staff == null)
            return NotFound();

        var staffDto = new StaffDto
        {
            Id = staff.Id,
            FirstName = staff.FirstName,
            SecondName = staff.SecondName,
            CommonName = staff.CommonName,
            Age = staff.DateOfBirth.HasValue
                ? DateTime.UtcNow.Year - staff.DateOfBirth.Value.Year
                : null
        };

        return Ok(staffDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateStaff(CreateStaffDto createStaffDto)
    {
        var staff = new Staff
        {
            FirstName = createStaffDto.FirstName,
            SecondName = createStaffDto.SecondName,
            CommonName = createStaffDto.CommonName,
            Name = createStaffDto.FirstName + " " + createStaffDto.SecondName
        };

        await staffService.AddStaffAsync(staff);
        return CreatedAtAction(nameof(GetStaffById), new { id = staff.Id }, staff);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateStaff(Guid id, CreateStaffDto updateStaffDto)
    {
        var staff = await staffService.GetStaffByIdAsync(id);

        if (staff == null)
            return NotFound();

        staff.FirstName = updateStaffDto.FirstName;
        staff.SecondName = updateStaffDto.SecondName;
        staff.CommonName = updateStaffDto.CommonName;

        await staffService.UpdateStaffAsync(staff);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteStaff(Guid id)
    {
        var nation = await staffService.GetStaffByIdAsync(id);

        if (nation == null)
            return NotFound();

        await staffService.DeleteStaffAsync(id);
        return NoContent();
    }
}