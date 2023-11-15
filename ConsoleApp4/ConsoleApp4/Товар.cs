using System;
using System;
using System.Collections.Generic;


public class Product : ISearchable
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public int Rating { get; set; }
}


public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public List<Order> PurchaseHistory { get; set; }
}


public class Order
{
    public List<Product> Products { get; set; }
    public int Quantity { get; set; }
    public double TotalCost { get; set; }
    public string Status { get; set; }
}


public interface ISearchable
{
    List<Product> SearchByName(string name);
    List<Product> SearchByCategory(string category);
    List<Product> SearchByPriceRange(double minPrice, double maxPrice);
    List<Product> SearchByRating(int rating);
}


public class Store : ISearchable
{
    private List<Product> products;
    private List<User> users;
    private List<Order> orders;

    public Store()
    {
        products = new List<Product>();
        users = new List<User>();
        orders = new List<Order>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public void AddUser(User user)
    {
        users.Add(user);
    }

    public void PlaceOrder(Order order)
    {
        orders.Add(order);
    }

    
    public List<Product> SearchByName(string name)
    {
        
        return products.FindAll(p => p.Name.ToLower().Contains(name.ToLower()));
    }

    public List<Product> SearchByCategory(string category)
    {
        
        return products.FindAll(p => p.Category.ToLower() == category.ToLower());
    }

    public List<Product> SearchByPriceRange(double minPrice, double maxPrice)
    {
        
        return products.FindAll(p => p.Price >= minPrice && p.Price <= maxPrice);
    }

    public List<Product> SearchByRating(int rating)
    {
        
        return products.FindAll(p => p.Rating >= rating);
    }
}

class Program
{
    static void Main(string[] args)
    {
        
    }
}
