using auction_api.Data;
using auction_api.Models;
using Microsoft.EntityFrameworkCore;
namespace auction_api.Repositories.Impl;

public class UserAuctionRepository(DataContext context) : IUserAuctionRepository
{
    public async Task<UserAuction?> GetUserAuctionAsync(Guid userId, Guid auctionId)
    {
        return await context.UserAuctions.
            FirstOrDefaultAsync(ua => ua.UserId == userId && ua.AuctionId == auctionId);
    }

    public async Task<IEnumerable<UserAuction>> GetUserAuctionsAsync(Guid userId)
    {
        return await context.UserAuctions
            .Where(ua => ua.UserId == userId)
            .ToListAsync();
    }

    public async Task AddUserAuctionAsync(UserAuction entity)
    {
        await context.UserAuctions.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateUserAuctionAsync(UserAuction entity)
    {
        context.UserAuctions.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteUserAuctionAsync(Guid userId, Guid auctionId)
    {
        var entity = await GetUserAuctionAsync(userId, auctionId);

        if (entity == null) return;

        context.UserAuctions.Remove(entity);
        await context.SaveChangesAsync();
    }
}



