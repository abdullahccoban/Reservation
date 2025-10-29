using Microsoft.AspNetCore.Mvc;
using Reservation.Application.DTOs.Requests.HotelAdmin;
using Reservation.Application.Interfaces;

namespace Reservation.Controllers;

[ApiController]
[Route("api/v1/hotelAdmin")]
public class HotelAdminController : ControllerBase
{
    private readonly IHotelAdminService _hotelAdminService;

    public HotelAdminController(IHotelAdminService hotelAdminService)
    {
        _hotelAdminService = hotelAdminService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateHotelAdminRequestDto request)
    {
        try
        {
            await _hotelAdminService.CreateHotelAdminAsync(request);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    
    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] UpdateHotelAdminRequestDto request)
    {
        try
        {
            await _hotelAdminService.UpdateHotelAdminAsync(request);
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
            await _hotelAdminService.RemoveHotelAdminAsync(id);
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
            var hotelAdmins = await _hotelAdminService.GetAllHotelAdminsAsync();
            return Ok(hotelAdmins);
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
            var hotelAdmin = await _hotelAdminService.GetHotelAdminByIdAsync(id);
            return Ok(hotelAdmin);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    
    [HttpGet("getAdminHotels")]
    public async Task<IActionResult> GetAdminHotels(string userEmail)
    {
        try
        {
            var hotelAdmins = await _hotelAdminService.GetHotelAdminsAsync(userEmail);
            return Ok(hotelAdmins);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}