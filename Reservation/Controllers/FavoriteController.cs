using Microsoft.AspNetCore.Mvc;
using Reservation.Application.DTOs.Requests.Favorite;
using Reservation.Application.Interfaces;

namespace Reservation.Controllers;

[ApiController]
[Route("api/v1/favorite")]
public class FavoriteController : ControllerBase
{
    private readonly IFavoriteService _favoriteService;

    public FavoriteController(IFavoriteService favoriteService)
    {
        _favoriteService = favoriteService;
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> AddFavorite([FromBody] AddFavoriteRequestDto request)
    {
        try
        {
            await _favoriteService.AddFavoriteAsync(request);
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
            await _favoriteService.RemoveFavoriteAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    
    [HttpGet("getFavorites")]
    public async Task<IActionResult> GetAllAnsweredByHotelId(string userId)
    {
        try
        {
            var favorites = await _favoriteService.GetFavoritesAsync(userId);
            return Ok(favorites);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}