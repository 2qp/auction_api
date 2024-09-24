using auction_api.Models;
using auction_api.Services;
using Microsoft.AspNetCore.Mvc;
namespace auction_api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(IUserService userService) : ControllerBase
{



    [HttpGet("Bids")]
    public async Task<ActionResult<IEnumerable<Bid>>> GetBids([FromRoute] string id)
    {
        var bids = await userService.GetAllBidsByUserId(id);
        return Ok(bids);
    }



}

