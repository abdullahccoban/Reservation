using GenericInfra.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reservation.Infrastructure.Context;
using Reservation.Infrastructure.Interfaces;
using Reservation.Infrastructure.Repositories;

namespace Reservation.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
            
        services.AddDbContext<ReservationDbContext>(options =>
            options.UseNpgsql(connectionString)
        );
        
        services.AddUnitOfWork<ReservationDbContext>();

        services.AddScoped<IHotelRepository, HotelRepository>();
        services.AddScoped<IHotelInformationRepository, HotelInformationRepository>();
        services.AddScoped<IPhotoRepository, PhotoRepository>();
        
        return services;
    } 
}