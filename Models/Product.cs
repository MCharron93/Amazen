namespace Amazen.Models
{
  public class Product
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsAvailable { get; set; }
    public string Picture { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
  }
  // In here you will add the ViewModel for the WishListProduct : Prodcuct here with a public prop int of WishListProductId from the relationship table
  public class ProudctWislListViewModel : Product
  {
    public int ProductWishListId { get; set; }
  }
}