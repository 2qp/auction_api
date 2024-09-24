
using auction_api.Models;
using auction_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace auction_api.Controllers;

[ApiController]
[Route("[controller]")]
public class BidController(IBidService bidService) : ControllerBase
{



    [HttpGet("Bid")]
    public void Get()
    {

    }

    [HttpPost("addBid")]
    public async Task PostAsync(Bid bid) => await bidService.AddBidAsync(bid);

}