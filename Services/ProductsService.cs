using System;
using System.Collections.Generic;
using Amazen.Models;
using Amazen.Repositories;

namespace Amazen.Services
{
  public class ProductsService
  {
    private readonly ProductsRepository _repo;

    public ProductsService(ProductsRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Product> GetAllProducts()
    {
      return _repo.GetAllProducts();
    }
  }
}