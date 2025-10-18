using Microsoft.IdentityModel.Tokens;
using task_3_tasks_manager.Models;

namespace task_3_tasks_manager;

public static class MenuPrinter
{
    public const string SUCCESS_ICON = "✅"; 
    public const string FAIL_ICON = "❌"; 
    public const string INFO_ICON = "⏺️"; 
    
    public static void PrintMainMenu()
    {
        Console.Clear();
        
        Console.WriteLine();
        Console.WriteLine("1. Show all tasks.");
        Console.WriteLine("2. Create new task.");
        Console.WriteLine("3. Exit.");
        Console.WriteLine();
    }
    
    public static void PrintMenuBar()
    {
        Console.WriteLine();
        Console.WriteLine("1. Back     2. Create new task.     3. Delete task    4. Change task status");
    }

    public static void Empty()
    {
        Console.WriteLine();
        Console.WriteLine("Data is empty.");
        Console.WriteLine();
    }
    
    public static void PrintTasks(IEnumerable<TaskItem> taskItems)
    {
        Console.WriteLine();

        if (!taskItems.Any())
        {
            Empty();
            return;
        }
        
        foreach (var taskItem in taskItems)
        {
            var isCompleted = taskItem.IsCompleted ? SUCCESS_ICON : INFO_ICON;
            
            Console.WriteLine($"{isCompleted} {taskItem.Id}.{taskItem.Title}");
            Console.WriteLine($"\t{taskItem.Description}");
            Console.WriteLine($"\t{taskItem.CreatedAt}");
            Console.WriteLine();
        }
    }

    public static void PrintTitle(string title)
    {
        Console.WriteLine();
        Console.WriteLine($"=== {title} ===");
        Console.WriteLine();
    }
    
    public static void PrintResult(string message, string icon = SUCCESS_ICON)
    {
        Console.WriteLine();
        Console.WriteLine($"{icon} {message}");
        Console.WriteLine("Press any key to continue...");
        Console.WriteLine();
    }
}
