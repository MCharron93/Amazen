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

    public Product CreateProduct(Product newProduct)
    {
      newProduct.Id = _repo.CreateProduct(newProduct);
      return newProduct;
    }

    public Product GetSingleProduct(int id)
    {
      return _repo.GetSingleProduct(id);
    }
  }
}