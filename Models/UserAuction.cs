namespace auction_api.Models;

public class UserAuction
{
    public Guid Id { get; set; }
    public required Guid UserId { get; set; }
    public User? User { get; set; }

    public required Guid AuctionId { get; set; }
    public Auction? Auction { get; set; }

    public required long StatusId { get; set; }
    public Status? Status { get; set; }
    public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
}
