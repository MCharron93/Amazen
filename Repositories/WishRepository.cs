using System;
using System.Collections.Generic;
using System.Data;
using Amazen.Models;
using Dapper;

namespace Amazen.Repositories
{
  public class WishRepository
  {
    private readonly IDbConnection _db;
    private readonly string populateCreator = "SELECT wishList.*, profile.* FROM wishLists wishlist INNER JOIN profiles profile ON wishlist.creatorId = profile.Id ";

    public WishRepository(IDbConnection db)
    {
      _db = db;
    }

    internal int CreateWish(Wish newWish)
    {
      string sql = @"
      INSERT INTO wishLists
      (name, creatorId)
      VALUES 
      (@Name, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      return _db.ExecuteScalar<int>(sql, newWish);
    }

    internal IEnumerable<Wish> GetAllWishs(string userId)
    {
      string sql = populateCreator + "WHERE creatorId = @userId";
      return _db.Query<Wish, Profile, Wish>(sql, (wishList, profile) => { wishList.Creator = profile; return wishList; }, new { userId }, splitOn: "id");
    }
  }
}