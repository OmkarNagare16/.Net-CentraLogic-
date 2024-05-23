using System;
using System.Collections.Generic;

public class Inventory
{
    private List<Item> items;

    // Constructor
    public Inventory()
    {
        items = new List<Item>();
    }

    // Method to add a new item
    public void AddItem(Item item)
    {
        items.Add(item);
        Console.WriteLine("Item added successfully.");
    }

    // Method to display all items
    public void DisplayItems()
    {
        Console.WriteLine("Inventory Items:");
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    // Method to find an item by ID
    public Item FindItemById(int id)
    {
        return items.Find(item => item.ID == id);
    }

    // Method to update an item's information
    public bool UpdateItem(int id, string name, int quantity, decimal price)
    {
        Item item = FindItemById(id);
        if (item != null)
        {
            item.Name = name;
            item.Quantity = quantity;
            item.Price = price;
            Console.WriteLine("Item updated successfully.");
            return true;
        }
        Console.WriteLine("Item not found.");
        return false;
    }

    // Method to delete an item
    public bool DeleteItem(int id)
    {
        Item item = FindItemById(id);
        if (item != null)
        {
            items.Remove(item);
            Console.WriteLine("Item deleted successfully.");
            return true;
        }
        Console.WriteLine("Item not found.");
        return false;
    }
}
