using System;
using System.Data;
using Amazen.Models;
using Dapper;

namespace Amazen.Repositories
{
  public class ProductWishListRepository
  {
    private readonly IDbConnection _db;

    public ProductWishListRepository(IDbConnection db)
    {
      _db = db;
    }

    internal int Create(ProductWishList newPWL)
    {
      string sql = @"
      INSERT INTO productWish
      (productId, wishListId, creatorId)
      VALUES
      (@ProductId, @WishListId, @CreatorId);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newPWL);
    }
  }
}