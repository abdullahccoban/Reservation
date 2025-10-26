using Microsoft.Extensions.DependencyInjection;
using Reservation.Application.Interfaces;
using Reservation.Application.Mappings;
using Reservation.Application.Services;

namespace Reservation.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(HotelMapping));
        services.AddAutoMapper(typeof(HotelInformationMapping));
        services.AddAutoMapper(typeof(PhotoMapping));
        services.AddAutoMapper(typeof(RoomMapping));
        services.AddAutoMapper(typeof(RoomFeatureMapping));
        services.AddAutoMapper(typeof(RoomPriceMapping));
        services.AddAutoMapper(typeof(PromotionMapping));
        services.AddAutoMapper(typeof(TagMapping));
        services.AddAutoMapper(typeof(WorkingRangeMapping));
        services.AddScoped<IHotelService, HotelService>();
        services.AddScoped<IHotelInformationService, HotelInformationService>();
        services.AddScoped<IPhotoService, PhotoService>();
        services.AddScoped<IRoomService, RoomService>();
        services.AddScoped<IRoomFeatureService, RoomFeatureService>();
        services.AddScoped<IRoomPriceService, RoomPriceService>();
        services.AddScoped<IPromotionService, PromotionService>();
        services.AddScoped<ITagService, TagService>();
        services.AddScoped<IWorkingRangeService, WorkingRangeService>();
        
        return services;
    } 
}