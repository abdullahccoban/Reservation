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
        services.AddScoped<IHotelService, HotelService>();
        
        return services;
    } 
}