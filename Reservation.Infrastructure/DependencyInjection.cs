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
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<IRoomPriceRepository, RoomPriceRepository>();
        services.AddScoped<IRoomFeatureRepository, RoomFeatureRepository>();
        services.AddScoped<IPromotionRepository, PromotionRepository>();
        services.AddScoped<IWorkingRangeRepository, WorkingRangeRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<IHotelAdminRepository, HotelAdminRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<IQaRepository, QaRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        
        return services;
    } 
}