using auction_api.Models;

namespace auction_api.Services;

public interface IBidService
{
    Task<IEnumerable<Bid>> GetAllBidsAsync();
    Task<Bid> GetBidByIdAsync(long id);
    Task AddBidAsync(Bid bid);
    Task UpdateBidAsync(Bid bid);
    Task DeleteBidAsync(long id);
}