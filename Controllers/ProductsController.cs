using System.Collections.Generic;
using Amazen.Models;
using Amazen.Services;
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

  }
}