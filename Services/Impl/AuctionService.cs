using auction_api.Models;
using auction_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace auction_api.Services.Impl;

public class AuctionService(IAuctionRepository repository) : IAuctionService
{

    public async Task<IEnumerable<Auction>> GetAllAuctionsAsync() => await repository.GetAllAsync();

    public Task<Auction?> GetAuctionByIdAsync(long id) => repository.GetByIdAsync(id);

    public Task AddAuctionAsync(Auction auction) => repository.AddAsync(auction);

    public Task UpdateAuctionAsync(Auction auction) => repository.UpdateAsync(auction);

    public Task DeleteAuctionAsync(long id) => repository.DeleteAsync(id);

    public Task JoinAuctionAsync(string groupId, string connectionId)
    {
        throw new NotImplementedException();
    }
}