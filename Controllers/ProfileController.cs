using Amazen.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Mvc;
using Amazen.Models;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace Amazen.Controllers
{
  [ApiController]
  [Route("[controller]")]

  public class ProfileController : ControllerBase
  {

    private readonly ProfileService _ps;

    public ProfileController(ProfileService ps)
    {
      _ps = ps;
    }

    [HttpGet]
    [Authorize]
    // NOTE this authorization will get back a profile, adds that layer of security on the requests.
    public async Task<ActionResult<Profile>> Get()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_ps.GetOrCreateProfile(userInfo));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    // [HttpGet("{id}/blogs")]
    // [Authorize]
    // // NOTE this authorization will get back a profile, adds that layer of security on the requests.
    // public async Task<ActionResult<Profile>> GetBlogsByProfile(string id)
    // {
    //   try
    //   {
    //     Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
    //     return Ok(_ps.GetBlogsByProfile(id, userInfo?.Id));
    //   }
    //   catch (System.Exception err)
    //   {
    //     return BadRequest(err.Message);
    //   }
    // }
  }
}