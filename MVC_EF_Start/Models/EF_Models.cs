using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_EF_Start.Models
{
  public class Order
  {
    //[Key]
    public int OrderID { get; set; }
    public int Quantity { get; set; }
    public int TotalCost { get; set; }
    public string date { get; set; }
    public List<OrderDetails> ItemsInOrder { get; set; }
  }

  public class Product
  {
    //[Key]
    public int ProductID { get; set; }
    public string name { get; set; }
    public string brand { get; set; }
    public int UnitPrice { get; set; }
    public List<OrderDetails> ProductOrders { get; set; }
  }

  public class OrderDetails
  {
    public int id { get; set; }
    public Order PlacedOrder { get; set; }
    public Product PurchasedItem { get; set; }
  }
}