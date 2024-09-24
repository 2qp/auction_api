namespace auction_api.Models;

public class Status
{
    public long Id { get; set; }
    public required string Title { get; set; }

    public List<Auction>? Auctions { get; set; }
    public List<UserAuction>? UserAuctions { get; set; }
}
