using Microsoft.AspNetCore.Mvc;
using Reservation.Application.DTOs.Requests.RoomPrice;
using Reservation.Application.Interfaces;

namespace Reservation.Controllers;

[ApiController]
[Route("api/v1/roomPrice")]
public class RoomPriceController : ControllerBase
{
    private readonly IRoomPriceService _roomPriceService;

    public RoomPriceController(IRoomPriceService roomPriceService)
    {
        _roomPriceService = roomPriceService;
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateRoomPriceRequestDto request)
    {
        try
        {
            await _roomPriceService.CreateRoomPriceAsync(request);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    
    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] UpdateRoomPriceRequestDto request)
    {
        try
        {
            await _roomPriceService.UpdateRoomPriceAsync(request);
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
            await _roomPriceService.RemoveRoomPriceAsync(id);
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
            var roomPrices = await _roomPriceService.GetAllRoomPricesAsync();
            return Ok(roomPrices);
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
            var roomPrice = await _roomPriceService.GetRoomPriceById(id);
            return Ok(roomPrice);
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
            var roomPrices = await _roomPriceService.GetHotelRoomPricesAsync(hotelId);
            return Ok(roomPrices);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}