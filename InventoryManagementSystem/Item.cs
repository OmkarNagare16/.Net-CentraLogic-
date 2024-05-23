using System;

public class Item
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    // Constructor
    public Item(int id, string name, int quantity, decimal price)
    {
        ID = id;
        Name = name;
        Quantity = quantity;
        Price = price;
    }

    // Override ToString for easy display of item information
    public override string ToString()
    {
        return $"ID: {ID}, Name: {Name}, Quantity: {Quantity}, Price: {Price:C}";
    }
}
