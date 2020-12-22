using System;
using System.Collections.Generic;
using System.Data;
using Amazen.Models;
using Dapper;

namespace Amazen.Repositories
{
  public class ProductsRepository
  {
    private readonly IDbConnection _db;

    public ProductsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Product> GetAllProducts()
    {
      string sql = "SELECT * FROM products WHERE isAvailable = 1";
      return _db.Query<Product>(sql);
    }
  }
}