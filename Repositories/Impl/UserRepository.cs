using auction_api.Data;
using auction_api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace auction_api.Repositories.Impl;

class UserRepository(DataContext context) : IUserRepository
{
    public async Task<IEnumerable<Bid>> GetAllBidsByIdAsync(Guid guid)
    {


        var user = await context.Users
               .Include(u => u.Bids)
               .SingleAsync(u => u.Id == guid);
        // .FirstAsync(u => u.Id == guid);


        if (user == null || user?.Bids == null)
        {
            return [];
        }

        return user.Bids;
    }
}