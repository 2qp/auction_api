

using Microsoft.AspNetCore.SignalR;

namespace auction_api.Hubs
{
    public class AuctionHub : Hub<IAuctionClient>
    {
        // string auctionId, 
        // internal async Task SendBidUpdate(string bidInfo)
        // {
        //     await Clients.All.ReceiveBids(bidInfo);
        // }

        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            // await Clients.Group(groupName).SendAsync("ReceiveMessage", $"{Context.ConnectionId} has joined the group.");

        }


    }
}