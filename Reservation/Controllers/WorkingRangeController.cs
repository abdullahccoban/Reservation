using Microsoft.AspNetCore.Mvc;
using Reservation.Application.DTOs.Requests.WorkingRange;
using Reservation.Application.Interfaces;

namespace Reservation.Controllers;

[ApiController]
[Route("api/v1/workingRange")]
public class WorkingRangeController : ControllerBase
{
    private readonly IWorkingRangeService _workingRangeService;

    public WorkingRangeController(IWorkingRangeService workingRangeService)
    {
        _workingRangeService = workingRangeService;
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateWorkingRangeRequestDto request)
    {
        try
        {
            await _workingRangeService.CreateWorkingRangeAsync(request);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    
    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] UpdateWorkingRangeRequestDto request)
    {
        try
        {
            await _workingRangeService.UpdateWorkingRangeAsync(request);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    
    [HttpPost("remove")]
    public async Task<IActionResult> Remove(int id)
    {
        try
        {
            await _workingRangeService.RemoveWorkingRangeAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var workingRanges = await _workingRangeService.GetAllWorkingRangesAsync();
            return Ok(workingRanges);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    
    [HttpGet("getById")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var workingRange = await _workingRangeService.GetWorkingRangeById(id);
            return Ok(workingRange);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    
    [HttpGet("getAllByHotelId")]
    public async Task<IActionResult> GetAllByHotelId(int hotelId)
    {
        try
        {
            var workingRanges = await _workingRangeService.GetHotelWorkingRangesAsync(hotelId);
            return Ok(workingRanges);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}