using auction_api.Models;
namespace auction_api.Repositories;

public interface IUserAuctionRepository
{
    Task<UserAuction?> GetUserAuctionAsync(Guid userId, Guid auctionId);
    Task<IEnumerable<UserAuction>> GetUserAuctionsAsync(Guid userId);
    Task AddUserAuctionAsync(UserAuction entity);
    Task UpdateUserAuctionAsync(UserAuction entity);
    Task DeleteUserAuctionAsync(Guid userId, Guid auctionId);
}

