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

    internal object GetSingleWish(int id)
    {
      throw new NotImplementedException();
    }

    internal object Delete(int id1, string id2)
    {
      throw new NotImplementedException();
    }
  }
}