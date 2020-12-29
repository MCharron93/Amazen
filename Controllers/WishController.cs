using System.Threading.Tasks;
using Amazen.Models;
using Amazen.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Amazen.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class WishController : ControllerBase
  {
    private readonly WishService _ws;

    public WishController(WishService ws)
    {
      _ws = ws;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Wish>> CreateWish([FromBody] Wish newWish)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newWish.CreatorId = userInfo.Id;
        Wish created = _ws.CreateWish(newWish);
        return Ok(created);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}