using Microsoft.AspNetCore.Mvc;
using Reservation.Application.DTOs.Requests.Hotel;
using Reservation.Application.Interfaces;

namespace Reservation.Controllers;

[ApiController]
[Route("api/v1/hotel")]
public class HotelController : ControllerBase
{
    private readonly IHotelService _hotelService;

    public HotelController(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateHotelRequestDto request)
    {
        try
        {
            await _hotelService.CreateHotelAsync(request);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    
    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] UpdateHotelRequestDto request)
    {
        try
        {
            await _hotelService.UpdateHotelAsync(request);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}