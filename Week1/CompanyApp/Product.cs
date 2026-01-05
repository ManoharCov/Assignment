using System;

class Product
{
    public int ProductId;
    public string ProductName;
    public double Price;

    public Product(int productId, string productName, double price)
    {
        ProductId = productId;
        ProductName = productName;
        Price = price;
    }

    public void Display()
    {
        Console.WriteLine($"ID: {ProductId}, Name: {ProductName}, Price: {Price}");
    }
}
