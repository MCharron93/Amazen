using System;
using System.Collections.Generic;
using Amazen.Models;
using Amazen.Repositories;

namespace Amazen.Services
{
  public class WishService
  {
    private readonly WishRepository _repo;

    public WishService(WishRepository repo)
    {
      _repo = repo;
    }

    public Wish CreateWish(Wish newWish)
    {
      newWish.Id = _repo.CreateWish(newWish);
      return newWish;
    }

    public IEnumerable<Wish> GetAllWishs(string userId)
    {

      return _repo.GetAllWishs(userId);
    }

    public Wish GetSingleWish(int id)
    {
      return _repo.GetSingleWish(id);
    }

    public string Delete(int id, string userId)
    {
      Wish original = _repo.GetSingleWish(id);
      if (original == null || original.CreatorId != userId)
      {
        throw new Exception("Invalid Request!");
      }
      if (_repo.Delete(id))
      {
        return "Successfully Deleted Wishlist";
      }
      return "Unsuccessful in Deleting Wishlist";
    }
  }
}