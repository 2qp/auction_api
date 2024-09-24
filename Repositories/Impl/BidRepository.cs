using auction_api.Data;
using auction_api.Models;

namespace auction_api.Repositories.Impl;


public class BidRepository(DataContext context) : IBidRepository
{
    public async Task AddAsync(Bid bid)
    {
        context.Bids.Add(bid);
        await context.SaveChangesAsync();
    }
}