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

  public class ProductsController : ControllerBase
  {
    private readonly ProductsService _pts;

    public ProductsController(ProductsService pts)
    {
      _pts = pts;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAllProducts()
    {
      try
      {
        return Ok(_pts.GetAllProducts());
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetSingleProduct(int id)
    {
      try
      {
        return Ok(_pts.GetSingleProduct(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Product>> CreateProduct([FromBody] Product newProduct)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newProduct.CreatorId = userInfo.Id;
        Product created = _pts.CreateProduct(newProduct);
        return Ok(created);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Product>> EditProduct(int id, [FromBody] Product editData)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        editData.Id = id;
        return Ok(_pts.Edit(editData, userInfo));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Product>> toggleAvailability(int id, [FromBody] Product editData)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        editData.Id = id;
        return Ok(_pts.toggleAvailable(editData, userInfo));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}