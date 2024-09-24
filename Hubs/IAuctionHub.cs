namespace auction_api.Hubs;
public interface IAuctionClient
{
    Task ReceiveBids(string bidInfo);

    // Task Join(string groupId);

}