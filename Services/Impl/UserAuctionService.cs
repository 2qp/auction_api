using auction_api.Models;
using auction_api.Repositories;
using auction_api.Services;

namespace auction_api.Services.Impl;

public class UserAuctionService(IUserAuctionRepository _UserAuctionRepository) : IUserAuctionService
{
    public Task<UserAuction?> GetUserAuctionAsync(string userId, string auctionId) =>
        _UserAuctionRepository.GetUserAuctionAsync(new Guid(userId), new Guid(auctionId));

    public Task<IEnumerable<UserAuction>> GetUserAuctionsAsync(string userId) =>
        _UserAuctionRepository.GetUserAuctionsAsync(new Guid(userId));

    public Task AddUserAuctionAsync(UserAuction entity) =>
        _UserAuctionRepository.AddUserAuctionAsync(entity);

    public Task UpdateUserAuctionAsync(UserAuction entity) =>
        _UserAuctionRepository.UpdateUserAuctionAsync(entity);

    public Task DeleteUserAuctionAsync(string userId, string auctionId) =>
        _UserAuctionRepository.DeleteUserAuctionAsync(new Guid(userId), new Guid(auctionId));
}
