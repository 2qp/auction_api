
using auction_api.Models;
using auction_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace auction_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserAuctionController(IUserAuctionService UserAuctionService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<UserAuction>> GetUserAuction([FromRoute] string userId, [FromRoute] string auctionId) =>
    await UserAuctionService.GetUserAuctionAsync(userId, auctionId) is UserAuction auction
        ? Ok(auction)
        : NotFound();

    [HttpGet("UserAuctions")]
    public async Task<ActionResult<IEnumerable<UserAuction>>> GetUserAuctions([FromRoute] string userId) =>
    await UserAuctionService.GetUserAuctionsAsync(userId) is var auctions
       ? Ok(auctions)
       : NotFound();

    [HttpPost]
    public async Task<ActionResult> AddUserAuction(string groupId, string connectionId, UserAuction entity)
    {
        await UserAuctionService.JoinAuctionAsync(groupId, connectionId, entity);
        return CreatedAtAction(nameof(GetUserAuction), new { userId = entity.UserId, auctionId = entity.AuctionId }, entity);
    }


    [HttpPut]
    public async Task<ActionResult> UpdateUserAuction(UserAuction entity) =>
       await UserAuctionService.UpdateUserAuctionAsync(entity).ContinueWith(t => NoContent());

    [HttpDelete]
    public async Task<ActionResult> DeleteUserAuction([FromRoute] string userId, [FromRoute] string auctionId) =>
       await UserAuctionService.DeleteUserAuctionAsync(userId, auctionId).ContinueWith(t => NoContent());
}