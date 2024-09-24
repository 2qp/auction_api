using auction_api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace auction_api.Data;

public class DataContext(DbContextOptions<DataContext> options) : IdentityDbContext<User, IdentityRole<Guid>, Guid>(options)
{

    public DbSet<Status> Statuses { get; set; }
    public DbSet<Auction> Auctions { get; set; }
    public DbSet<Bid> Bids { get; set; }
    public DbSet<UserAuction> UserAuctions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder); // Call the base method



        modelBuilder.Entity<User>().HasKey(m => m.Id);
        modelBuilder.Entity<Bid>().HasKey(m => m.Id);
        // modelBuilder.Entity<Auction>().HasKey(m => m.Id);
        // modelBuilder.Entity<Status>().HasKey(m => m.Id);


        modelBuilder.Entity<Bid>()
        .HasOne(b => b.Bidder) // Bid has one Bidder
        .WithMany(u => u.Bids) // User has many Bids
        .HasForeignKey(b => b.BidderId)
        .OnDelete(DeleteBehavior.NoAction);


        modelBuilder.Entity<Bid>().HasOne(b => b.Auction) // Bid has one auction
        .WithMany(u => u.Bids) // Auction has many bids
        .HasForeignKey(b => b.AuctionId)
        .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Status>()
        .HasMany(b => b.Auctions) // Status has many Auctions
        .WithOne(u => u.Status) // Auction has one status
        .HasForeignKey(b => b.StatusId)
        .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<UserAuction>().HasOne(b => b.Auction) // UserAuction has one auction
        .WithMany(u => u.UserAuctions) // Auction has many UserAuctions
        .HasForeignKey(b => b.AuctionId)
        .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<UserAuction>().HasOne(b => b.Status) // UserAuction has one Status
        .WithMany(u => u.UserAuctions) // Status has many UserAuctions
        .HasForeignKey(b => b.StatusId)
        .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<UserAuction>().HasOne(b => b.User) // UserAuction has one User
        .WithMany(u => u.UserAuctions) // User has many UserAuctions
        .HasForeignKey(b => b.UserId)
        .OnDelete(DeleteBehavior.NoAction);

        //         modelBuilder.Entity<UserAuction>(entity =>
        // {
        //     entity.HasOne(b => b.Auction)
        //         .WithMany(u => u.UserAuctions)
        //         .HasForeignKey(b => b.AuctionId)
        //         .OnDelete(DeleteBehavior.NoAction);

        //     entity.HasOne(b => b.Status)
        //         .WithMany(u => u.UserAuctions)
        //         .HasForeignKey(b => b.StatusId)
        //         .OnDelete(DeleteBehavior.NoAction);

        //     entity.HasOne(b => b.User)
        //         .WithMany(u => u.UserAuctions)
        //         .HasForeignKey(b => b.UserId)
        //         .OnDelete(DeleteBehavior.NoAction);
        // });


        modelBuilder.Entity<Auction>()
        .HasOne(b => b.User) // Auction has one User
        .WithMany(u => u.Auctions) // User has many Auctions
        .HasForeignKey(b => b.UserId)
        .OnDelete(DeleteBehavior.NoAction);





    }
}