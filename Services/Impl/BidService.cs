using auction_api.Hubs;
using auction_api.Models;
using auction_api.Repositories;
using Microsoft.AspNetCore.SignalR;

namespace auction_api.Services.Impl;


public class BidService(IBidRepository bidRepository, IHubContext<AuctionHub, IAuctionClient> hub) : IBidService
{
    public async Task AddBidAsync(Bid bid)
    {
        Console.WriteLine("ddsd");
        // Console.WriteLine(bid.ToString());

        await bidRepository.AddAsync(bid);

        var _groupId = bid.AuctionId.ToString();

        await hub.Clients.Group(_groupId).ReceiveBids(bid.Amount.ToString());
    }

    public Task DeleteBidAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Bid>> GetAllBidsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Bid> GetBidByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateBidAsync(Bid bid)
    {
        throw new NotImplementedException();
    }
}