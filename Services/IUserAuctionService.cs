

using auction_api.Models;

namespace auction_api.Services;

public interface IUserAuctionService
{
    Task<UserAuction?> GetUserAuctionAsync(string userId, string auctionId);
    Task<IEnumerable<UserAuction>> GetUserAuctionsAsync(string userId);
    Task AddUserAuctionAsync(UserAuction entity);
    Task UpdateUserAuctionAsync(UserAuction entity);
    Task DeleteUserAuctionAsync(string userId, string auctionId);
}