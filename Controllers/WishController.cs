using System.Collections.Generic;
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
    private readonly ProductWishListService _pwl;

    public WishController(WishService ws, ProductWishListService pwl)
    {
      _ws = ws;
      _pwl = pwl;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Wish>> CreateWish([FromBody] Wish newWish)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newWish.Creator = userInfo;
        newWish.CreatorId = userInfo.Id;
        Wish created = _ws.CreateWish(newWish);
        return Ok(created);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Wish>>> GetAllWishsAsync()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        string userId = userInfo.Id;
        return Ok(_ws.GetAllWishs(userId));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Wish> GetSingleWish(int id)
    {
      try
      {
        return Ok(_ws.GetSingleWish(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{wishId}/products")]
    [Authorize]
    public ActionResult<IEnumerable<Product>> GetProductsByWishId(int wishId)
    {
      try
      {
        return Ok(_pwl.GetProductsByWishId(wishId));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> Delete(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_ws.Delete(id, userInfo.Id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}