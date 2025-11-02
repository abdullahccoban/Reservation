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
    
    [HttpGet("searchHotels")]
    public async Task<IActionResult> SearchHotels([FromQuery] HotelSearchRequestDto request)
    {
        var hotels = await _hotelService.SearchHotels(request);
        return Ok(hotels);
    }
    
    [HttpGet("getHotelsForAdmins")]
    public async Task<IActionResult> GetHotelsForAdmins(string email)
    {
        var hotels = await _hotelService.GetHotelsForAdmins(email);
        return Ok(hotels);
    }

    [HttpGet("getHotelsCard")]
    public async Task<IActionResult> GetHotelsCard()
    {
        var cards = await _hotelService.GetHotelCards();
        return Ok(cards);
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
    
    [HttpPost("remove")]
    public async Task<IActionResult> Remove(int id)
    {
        try
        {
            await _hotelService.RemoveHotelAsync(id);
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
            var hotels = await _hotelService.GetHotelsAsync();
            return Ok(hotels);
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
            var hotel = await _hotelService.GetHotelByIdAsync(id);
            return Ok(hotel);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}