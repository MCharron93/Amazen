using System;
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

    internal object GetAllWishs()
    {
      throw new NotImplementedException();
    }

    internal object GetSingleWish(int id)
    {
      throw new NotImplementedException();
    }
  }
}