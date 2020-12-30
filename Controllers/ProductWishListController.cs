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
  public class ProductWishListController : ControllerBase
  {
    private readonly ProductWishListService _pwl;

    public ProductWishListController(ProductWishListService pwl)
    {
      _pwl = pwl;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<ProductWishList>> Create([FromBody] ProductWishList newPWL)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newPWL.CreatorId = userInfo.Id;
        Product created = _pwl.Create(newPWL);
        return Ok(created);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }


  }
}