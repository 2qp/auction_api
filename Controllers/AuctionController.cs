using auction_api.Models;
using auction_api.Services;
using Microsoft.AspNetCore.Mvc;
namespace auction_api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuctionController(IAuctionService auctionService) : ControllerBase
{

    [HttpGet("Auction")]
    public async Task<ActionResult<Auction>> GetAuction([FromRoute] long id) => await auctionService.GetAuctionByIdAsync(id).ContinueWith(a =>
    {

        if (a.IsFaulted) return StatusCode(500, "Internal server error");

        var auction = a.Result;
        if (auction == null) NotFound();

        return Ok(a.Result);
    });


    [HttpGet("Auctions")]
    public async Task<ActionResult<IEnumerable<Auction>>> GetAuctions() => await auctionService.GetAllAuctionsAsync().ContinueWith(a => Ok(a));


    [HttpPost]
    public async Task<ActionResult<Auction>> PostAuction(Auction auction)
    {
        await auctionService.AddAuctionAsync(auction);
        return CreatedAtAction(nameof(GetAuction), new { id = auction.Id }, auction);
    }

    [HttpPut]
    public async Task<IActionResult> PutAuction([FromRoute] Guid id, Auction auction)
    {
        if (id != auction.Id)
        {
            return BadRequest();
        }

        await auctionService.UpdateAuctionAsync(auction);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProduct([FromRoute] long id)
    {
        await auctionService.DeleteAuctionAsync(id);
        return NoContent();
    }
}

