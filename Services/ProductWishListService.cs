using System;
using Amazen.Models;
using Amazen.Repositories;

namespace Amazen.Services
{
  public class ProductWishListService
  {
    private readonly ProductWishListRepository _repo;

    public ProductWishListService(ProductWishListRepository repo)
    {
      _repo = repo;
    }

    internal ProductWishList Create(ProductWishList newPWL)
    {
      newPWL.Id = _repo.Create(newPWL);
      return newPWL;
    }
  }
}