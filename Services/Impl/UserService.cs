using auction_api.Models;
using auction_api.Repositories;

namespace auction_api.Services.Impl;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<IEnumerable<Bid>> GetAllBidsByUserId(string id) => await userRepository.GetAllBidsByIdAsync(new Guid(id));

}