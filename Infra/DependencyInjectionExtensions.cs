
namespace auction_api.Infra;

using auction_api.Repositories;
using auction_api.Repositories.Impl;
using auction_api.Services;
using auction_api.Services.Impl;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjectionExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IBidService, BidService>();
        services.AddScoped<IBidRepository, BidRepository>();

        services.AddScoped<IBidService, BidService>();
        services.AddScoped<IBidRepository, BidRepository>();

        services.AddScoped<IAuctionService, AuctionService>();
        services.AddScoped<IAuctionRepository, AuctionRepository>();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}
