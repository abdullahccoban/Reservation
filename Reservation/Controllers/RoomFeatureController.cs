using Microsoft.AspNetCore.Mvc;
using Reservation.Application.DTOs.Requests.RoomFeature;
using Reservation.Application.Interfaces;

namespace Reservation.Controllers;

[ApiController]
[Route("api/v1/roomFeature")]
public class RoomFeatureController : ControllerBase
{
    private readonly IRoomFeatureService _roomFeatureService;

    public RoomFeatureController(IRoomFeatureService roomFeatureService)
    {
        _roomFeatureService = roomFeatureService;
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateRoomFeatureRequestDto request)
    {
        try
        {
            await _roomFeatureService.CreateRoomFeatureAsync(request);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    
    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] UpdateRoomFeatureRequestDto request)
    {
        try
        {
            await _roomFeatureService.UpdateRoomFeatureAsync(request);
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
            await _roomFeatureService.RemoveRoomFeatureAsync(id);
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
            var roomFeatures = await _roomFeatureService.GetAllRoomFeaturesAsync();
            return Ok(roomFeatures);
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
            var roomFeature = await _roomFeatureService.GetRoomFeatureById(id);
            return Ok(roomFeature);
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
            var roomFeatures = await _roomFeatureService.GetHotelRoomFeaturesAsync(hotelId);
            return Ok(roomFeatures);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}