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

    public string Edit(Product editData, Profile userInfo)
    {
      Product original = GetSingleProduct(editData.Id);
      if (original.CreatorId == userInfo.Id)
      {
        editData.Name = editData.Name == null ? original.Name : editData.Name;
        editData.Description = editData.Description == null ? original.Description : editData.Description;
        editData.Picture = editData.Picture == null ? original.Picture : editData.Picture;
        _repo.Edit(editData);
        return "Successfully Updated";
      }
      else
      {
        throw new Exception("Access Denied.");
      }
    }

    public string toggleAvailable(Product editData, Profile userInfo)
    {
      if (editData.CreatorId == userInfo.Id)
      {
        if (editData.IsAvailable == true)
        {
          editData.IsAvailable = false;
          _repo.toggleAvailability(editData);
          return "Item is Out of Stock";
        }
        else if (editData.IsAvailable == false)
        {
          editData.IsAvailable = true;
          _repo.toggleAvailability(editData);
          return "Item is Back in Stock";
        }
        return "The item has been updated";
      }
      else
      {
        return "Access Denied.";
      }
    }
  }
}