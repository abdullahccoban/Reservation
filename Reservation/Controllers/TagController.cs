using Microsoft.AspNetCore.Mvc;
using Reservation.Application.DTOs.Requests.Tag;
using Reservation.Application.Interfaces;

namespace Reservation.Controllers;

[ApiController]
[Route("api/v1/tag")]
public class TagController : ControllerBase
{
    private readonly ITagService _tagService;

    public TagController(ITagService tagService)
    {
        _tagService = tagService;
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateTagRequestDto request)
    {
        try
        {
            await _tagService.CreateTagAsync(request);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    
    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] UpdateTagRequestDto request)
    {
        try
        {
            await _tagService.UpdateTagAsync(request);
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
            await _tagService.RemoveTagAsync(id);
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
            var tags = await _tagService.GetAllTagsAsync();
            return Ok(tags);
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
            var tag = await _tagService.GetTagById(id);
            return Ok(tag);
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
            var tags = await _tagService.GetHotelTagsAsync(hotelId);
            return Ok(tags);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}