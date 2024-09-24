using auction_api.Models;

namespace auction_api.Repositories;

public interface IAuctionRepository
{
    Task<IEnumerable<Auction>> GetAllAsync();
    Task<Auction?> GetByIdAsync(long id);
    Task AddAsync(Auction product);
    Task UpdateAsync(Auction product);
    Task DeleteAsync(long id);
}