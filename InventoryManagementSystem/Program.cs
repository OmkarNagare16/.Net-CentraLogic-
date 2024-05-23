using System;

class Program
{
    static void Main()
    {
        Inventory inventory = new Inventory();

        // Adding items to inventory
        inventory.AddItem(new Item(1, "Laptop", 10, 999.99m));
        inventory.AddItem(new Item(2, "Mouse", 50, 19.99m));
        inventory.AddItem(new Item(3, "Keyboard", 20, 49.99m));

        // Display all items
        inventory.DisplayItems();

        // Find an item by ID
        Item item = inventory.FindItemById(2);
        if (item != null)
        {
            Console.WriteLine($"Found item: {item}");
        }

        // Update an item
        bool updated = inventory.UpdateItem(3, "Mechanical Keyboard", 15, 79.99m);
        if (updated)
        {
            inventory.DisplayItems();
        }

        // Delete an item
        bool deleted = inventory.DeleteItem(1);
        if (deleted)
        {
            inventory.DisplayItems();
        }
    }
}
