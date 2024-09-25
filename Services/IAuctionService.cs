using auction_api.Models;

namespace auction_api.Services;
public interface IAuctionService
{
    Task<IEnumerable<Auction>> GetAllAuctionsAsync();
    Task<Auction?> GetAuctionByIdAsync(long id);
    Task AddAuctionAsync(Auction auction);
    Task UpdateAuctionAsync(Auction auction);
    Task DeleteAuctionAsync(long id);
}