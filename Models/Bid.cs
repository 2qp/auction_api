using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TextTemplating;

namespace auction_api.Models;

public class Bid
{
    public Guid Id { get; set; }
    public required Guid BidderId { get; set; }
    public User? Bidder { get; set; }
    public required Guid AuctionId { get; set; }
    public Auction? Auction { get; set; }
    public decimal Amount { get; set; }
    public DateTime? BidTime { get; set; } = DateTime.UtcNow;
    public bool IsWinningBid { get; set; } = false;

    public override string ToString()
    {
        return $"BidderId: {BidderId}, AuctionId: {AuctionId} {Amount}, Salary: {BidTime:C} Winning {IsWinningBid}";
    }

}