using Microsoft.AspNetCore.Mvc;
using Reservation.Application.DTOs.Requests.HotelInformation;
using Reservation.Application.Interfaces;

namespace Reservation.Controllers;

[ApiController]
[Route("api/v1/hotelInfo")]
public class HotelInformationController : ControllerBase
{
    private readonly IHotelInformationService _hotelInfoService;

    public HotelInformationController(IHotelInformationService hotelInfoService)
    {
        _hotelInfoService = hotelInfoService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateHotelInformationRequestDto request)
    {
        try
        {
            await _hotelInfoService.CreateHotelInformationAsync(request);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    
    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] UpdateHotelInformationRequestDto request)
    {
        try
        {
            await _hotelInfoService.UpdateHotelInformationAsync(request);
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
            await _hotelInfoService.RemoveHotelInformationAsync(id);
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
            var hotelInfos = await _hotelInfoService.GetAllHotelInformationsAsync();
            return Ok(hotelInfos);
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
            var hotelInfo = await _hotelInfoService.GetHotelInformationByIdAsync(id);
            return Ok(hotelInfo);
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
            var hotelInfos = await _hotelInfoService.GetHotelInformationsAsync(hotelId);
            return Ok(hotelInfos);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}