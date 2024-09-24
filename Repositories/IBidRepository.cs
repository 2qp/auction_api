using auction_api.Models;

namespace auction_api.Repositories;

public interface IBidRepository
{

    Task AddAsync(Bid bid);

}

