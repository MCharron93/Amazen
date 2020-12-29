using System.Data;
using Amazen.Models;
using Dapper;

namespace Amazen.Repositories
{
  public class WishRepository
  {
    private readonly IDbConnection _db;

    public WishRepository(IDbConnection db)
    {
      _db = db;
    }

    internal int CreateWish(Wish newWish)
    {
      string sql = @"
      INSERT INTO wishLists
      (name, creator, creatorId)
      VALUES 
      (@Name, @Creator, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      return _db.ExecuteScalar<int>(sql, newWish);
    }
  }
}