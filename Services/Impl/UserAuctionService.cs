using auction_api.Hubs;
using auction_api.Models;
using auction_api.Repositories;
using auction_api.Services;
using Microsoft.AspNetCore.SignalR;

namespace auction_api.Services.Impl;

public class UserAuctionService(IUserAuctionRepository _UserAuctionRepository, IHubContext<AuctionHub, IAuctionClient> hubContext) : IUserAuctionService
{
    public Task<UserAuction?> GetUserAuctionAsync(string userId, string auctionId) => _UserAuctionRepository.GetUserAuctionAsync(new Guid(userId), new Guid(auctionId));

    public Task<IEnumerable<UserAuction>> GetUserAuctionsAsync(string userId) => _UserAuctionRepository.GetUserAuctionsAsync(new Guid(userId));

    public async Task AddUserAuctionAsync(UserAuction entity) => await _UserAuctionRepository.AddUserAuctionAsync(entity);

    public Task UpdateUserAuctionAsync(UserAuction entity) => _UserAuctionRepository.UpdateUserAuctionAsync(entity);

    public Task DeleteUserAuctionAsync(string userId, string auctionId) => _UserAuctionRepository.DeleteUserAuctionAsync(new Guid(userId), new Guid(auctionId));

    public async Task JoinAuctionAsync(string groupId, string connectionId, UserAuction entity)
    {
        await AddUserAuctionAsync(entity);
        await hubContext.Groups.AddToGroupAsync(connectionId, groupId);
    }
}
