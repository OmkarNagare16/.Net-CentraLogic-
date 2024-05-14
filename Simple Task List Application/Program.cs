using System;
using System.Collections.Generic;

class Program
{
    static List<Task> tasks = new List<Task>();

    static void Main(string[] args)
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Task List Application");
            Console.WriteLine("1. Create a task");
            Console.WriteLine("2. Read tasks");
            Console.WriteLine("3. Update a task");
            Console.WriteLine("4. Delete a task");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    CreateTask();
                    break;
                case 2:
                    ReadTasks();
                    break;
                case 3:
                    UpdateTask();
                    break;
                case 4:
                    DeleteTask();
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;
            }
        }
    }

    static void CreateTask()
    {
        Console.Write("Enter task title: ");
        string title = Console.ReadLine();
        Console.Write("Enter task description: ");
        string description = Console.ReadLine();
        tasks.Add(new Task(title, description));
        Console.WriteLine("Task created successfully!");
    }

    static void ReadTasks()
    {
        Console.WriteLine("Tasks:");
        foreach (Task task in tasks)
        {
            Console.WriteLine($"- Title: {task.Title}, Description: {task.Description}");
        }
    }

    static void UpdateTask()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available to update.");
            return;
        }

        Console.WriteLine("Tasks:");
        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i].Title}");
        }

        Console.Write("Enter task number to update: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index < 0 || index >= tasks.Count)
        {
            Console.WriteLine("Invalid task number.");
            return;
        }

        Console.Write("Enter new title: ");
        string newTitle = Console.ReadLine();
        Console.Write("Enter new description: ");
        string newDescription = Console.ReadLine();
        tasks[index].Title = newTitle;
        tasks[index].Description = newDescription;

        Console.WriteLine("Task updated successfully!");
    }

    static void DeleteTask()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available to delete.");
            return;
        }

        Console.WriteLine("Tasks:");
        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i].Title}");
        }

        Console.Write("Enter task number to delete: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index < 0 || index >= tasks.Count)
        {
            Console.WriteLine("Invalid task number.");
            return;
        }

        tasks.RemoveAt(index);
        Console.WriteLine("Task deleted successfully!");
    }
}

class Task
{
    public string Title { get; set; }
    public string Description { get; set; }

    public Task(string title, string description)
    {
        Title = title;
        Description = description;
    }
}
