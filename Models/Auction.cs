namespace auction_api.Models;


public class Auction
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required long StatusId { get; set; }
    public Status? Status { get; set; }

    public required Guid UserId { get; set; }
    public User? User { get; set; }

    public List<Bid>? Bids { get; set; }

    public List<UserAuction>? UserAuctions { get; set; }
}