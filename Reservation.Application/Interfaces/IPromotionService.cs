using Reservation.Application.DTOs.Requests.Promotion;
using Reservation.Application.DTOs.Responses.Promotion;

namespace Reservation.Application.Interfaces;

public interface IPromotionService
{
    Task CreatePromotionAsync(CreatePromotionRequestDto request);
    Task UpdatePromotionAsync(UpdatePromotionRequestDto request);
    Task RemovePromotionAsync(int id);
    Task<List<PromotionDto>> GetAllPromotionsAsync();
    Task<PromotionDto> GetPromotionById(int id);
    Task<List<PromotionDto>> GetHotelPromotionsAsync(int hotelId);
}