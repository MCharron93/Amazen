using System;
using System.Collections.Generic;
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

    internal IEnumerable<Product> GetProductsByWishId(int wishId)
    {
      return _repo.GetProductsByWishList(wishId);
    }
  }
}