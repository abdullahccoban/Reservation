using Microsoft.AspNetCore.Mvc;
using Reservation.Application.DTOs.Requests.Qa;
using Reservation.Application.Interfaces;

namespace Reservation.Controllers;

[ApiController]
[Route("api/v1/qa")]
public class QaController : ControllerBase
{
    private readonly IQaService _qaService;

    public QaController(IQaService qaService)
    {
        _qaService = qaService;
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateQaRequestDto request)
    {
        try
        {
            await _qaService.CreateQaAsync(request);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    
    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] UpdateQaRequestDto request)
    {
        try
        {
            await _qaService.UpdateQaAsync(request);
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
            await _qaService.RemoveQaAsync(id);
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
            var qas = await _qaService.GetAllQasAsync();
            return Ok(qas);
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
            var qa = await _qaService.GetQaById(id);
            return Ok(qa);
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
            var qas = await _qaService.GetHotelQasAsync(hotelId);
            return Ok(qas);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}