
using auction_api.Models;
using auction_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace auction_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserAuctionController(IUserAuctionService UserAuctionService) : ControllerBase
{
    public async Task<ActionResult<UserAuction>> GetUserAuction([FromRoute] string userId, [FromRoute] string auctionId) =>
       await UserAuctionService.GetUserAuctionAsync(userId, auctionId).ContinueWith(t =>
        {
            if (t.IsFaulted) return StatusCode(500, "Internal server error");

            var auction = t.Result;
            if (auction == null) NotFound();

            return Ok(t.Result);
        });

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserAuction>>> GetUserAuctions([FromRoute] string userId) =>
       await UserAuctionService.GetUserAuctionsAsync(userId).ContinueWith(t => Ok(t.Result));

    [HttpPost]
    public async Task<ActionResult> AddUserAuction(UserAuction entity) =>
       await UserAuctionService.AddUserAuctionAsync(entity).ContinueWith(t => CreatedAtAction(nameof(GetUserAuction), new { userId = entity.UserId, auctionId = entity.AuctionId }, entity));

    [HttpPut]
    public async Task<ActionResult> UpdateUserAuction(UserAuction entity) =>
       await UserAuctionService.UpdateUserAuctionAsync(entity).ContinueWith(t => NoContent());

    [HttpDelete]
    public async Task<ActionResult> DeleteUserAuction([FromRoute] string userId, [FromRoute] string auctionId) =>
       await UserAuctionService.DeleteUserAuctionAsync(userId, auctionId).ContinueWith(t => NoContent());
}