namespace auction_api.Repositories.Impl;

using auction_api.Data;
using auction_api.Models;
using Microsoft.EntityFrameworkCore;

public class AuctionRepository(DataContext context) : IAuctionRepository
{

    public async Task<IEnumerable<Auction>> GetAllAsync() => await context.Auctions.ToListAsync();


    public async Task<Auction?> GetByIdAsync(long id) => await context.Auctions.FindAsync(id);


    public async Task AddAsync(Auction product)
    {
        context.Auctions.Add(product);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Auction product)
    {
        context.Entry(product).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var product = await context.Auctions.FindAsync(id);

        if (product == null) return;

        context.Auctions.Remove(product);
        await context.SaveChangesAsync();

    }

}