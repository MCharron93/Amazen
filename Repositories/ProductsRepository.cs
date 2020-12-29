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

    internal int CreateProduct(Product newProduct)
    {
      string sql = @"
      INSERT INTO products
      (name, isAvailable, picture, creatorId)
      VALUES 
      (@Name, @IsAvailable, @Picture, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      return _db.ExecuteScalar<int>(sql, newProduct);
    }

    internal Product GetSingleProduct(int id)
    {
      string sql = @"SELECT * FROM products WHERE id = @id";
      return _db.QueryFirstOrDefault<Product>(sql, new { id });
    }

    internal void Edit(Product editData)
    {
      string sql = @"
      UPDATE products
      SET 
      name = @Name,
      description = @Description,
      picture = @Picture
      WHERE id = @Id;";
      _db.Execute(sql, editData);
    }

    internal void toggleAvailability(Product editData)
    {
      string sql = @"
      UPDATE products 
      SET 
      isAvailable = @IsAvailable
      WHERE id = @Id;";
      _db.Execute(sql, editData);
    }

    internal bool Delete(int id)
    {
      string sql = "DELETE FROM products WHERE id = @Id";
      int valid = _db.Execute(sql, new { id });
      return valid > 0;
    }
  }
}