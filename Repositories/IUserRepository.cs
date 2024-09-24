using auction_api.Models;

namespace auction_api.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<Bid>> GetAllBidsByIdAsync(Guid id);

}