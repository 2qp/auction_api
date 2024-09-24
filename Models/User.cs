using Microsoft.AspNetCore.Identity;

namespace auction_api.Models;

public class User : IdentityUser<Guid>
{
    public List<Auction>? Auctions { get; set; }
    public List<Bid>? Bids { get; set; }
    public List<UserAuction>? UserAuctions { get; set; }
}