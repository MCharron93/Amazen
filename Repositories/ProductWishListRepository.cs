using System;
using System.Collections.Generic;
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

    internal IEnumerable<Product> GetProductsByWishList(int wishId)
    {
      string sql = @"
      SELECT pd.*,
      pwl.id as ProductWishListId,
      p.*
      FROM productwish pwl
      JOIN products pd ON pd.id = pwl.productId
      JOIN profiles p ON p.id = pwl.creatorId
      WHERE wishListId = @wishId;
      ";
      return _db.Query<ProudctWislListViewModel, Profile, ProudctWislListViewModel>(sql, (product, profile) => { product.Creator = profile; return product; }, new { wishId }, splitOn: "id");
    }
  }
}