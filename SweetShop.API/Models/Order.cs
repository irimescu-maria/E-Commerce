using System;
using System.Collections.Generic;

namespace SweetShop.API.Models
{
    public class Order
    {
public int Id { get; set; }
public string Username { get; set; }
public string FirstName { get; set; }   
public string LastName { get; set; }
public string Address { get; set; }
public string PhoneNumber { get; set; }

public decimal Total { get; set; }
public DateTime OrderPlaced { get; set; }
public List<OrderDetail> OrderDetails { get; set; }
    }
}