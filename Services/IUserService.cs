using auction_api.Models;

namespace auction_api.Services;

public interface IUserService
{
    Task<IEnumerable<Bid>> GetAllBidsByUserId(string id);
}