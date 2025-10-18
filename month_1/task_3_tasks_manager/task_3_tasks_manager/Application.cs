using task_3_tasks_manager.Contracts;
using task_3_tasks_manager.Helpers;
using task_3_tasks_manager.Models;

namespace task_3_tasks_manager;

public enum AppState
{
    MainMenu,
    TasksList,
    CreateTask,
    DeleteTask,
    EditTask,
    Exit
}

public class Application(IService<TaskItem> taskService)
{
    private AppState _currentState = AppState.MainMenu;

    public async Task Run()
    {
        while (_currentState != AppState.Exit)
        {
            try
            {
                await RenderCurrentState();
                HandleInput();
            }
            catch (Exception e)
            {
                MenuPrinter.PrintResult(e.Message, MenuPrinter.FAIL_ICON);
                MenuPrinter.PrintMenuBar();
                var key = Console.ReadLine()?.Trim();
                HandleBarInput(key);
            }
        }
    }

    private async Task RenderCurrentState()
    {
        Console.Clear();
        
        switch (_currentState)
        {
            case AppState.MainMenu:
                MenuPrinter.PrintMainMenu();
                break;
            case AppState.TasksList:
                var tasks = await taskService.GetAll();
                MenuPrinter.PrintTasks(tasks);
                MenuPrinter.PrintMenuBar();
                break;
            case AppState.CreateTask:
                await ShowCreateTaskForm();
                break;
            case AppState.EditTask:
                await ShowEditTaskForm();
                break;
            case AppState.DeleteTask:
                await ShowDeleteTaskForm();
                break;
        }
    }

    private void HandleInput()
    {
        var input = Console.ReadLine()?.Trim();

        switch (_currentState)
        {
            case AppState.MainMenu:
                HandleMainMenuInput(input);
                break;
            case AppState.TasksList:
                HandleBarInput(input);
                break;
        }
    }

    private void HandleMainMenuInput(string input)
    {
        switch (input)
        {
            case "1": _currentState = AppState.TasksList; break;
            case "2": _currentState = AppState.CreateTask; break;
            case "3": _currentState = AppState.Exit; break;
        }
    }

    private void HandleBarInput(string input)
    {
        switch (input)
        {
            case "1": _currentState = AppState.MainMenu; break;
            case "2": _currentState = AppState.CreateTask; break;
            case "3": _currentState = AppState.DeleteTask; break;
            case "4": _currentState = AppState.EditTask; break;
        }
    }

    private bool ConfirmAction()
    {
        Console.WriteLine("Confirm action (Y/N):");
        var key = Console.ReadLine();
        
        return key is "Y" or "y";
    }
    
    private async Task ShowCreateTaskForm()
    {
        MenuPrinter.PrintTitle("Create Task");

        var newTask = new TaskItem
        {
            Title = ConsoleInputValidator.GetRequiredString("Title", 100),
            Description = ConsoleInputValidator.GetRequiredString("Description", 500),
            IsCompleted = ConsoleInputValidator.GetYesNo("IsCompleted")
        };

        if (await taskService.Add(newTask))
        {
            MenuPrinter.PrintResult("Task Created!");
        }
        else
        {
            MenuPrinter.PrintResult("Task Creating Failed!", MenuPrinter.FAIL_ICON);
        }

        _currentState = AppState.MainMenu;
    }
    
    private async Task ShowEditTaskForm()
    {
        MenuPrinter.PrintTitle("Change Task Status");
        
        Console.Write("Enter Task ID: ");
        if (!int.TryParse(Console.ReadLine(), out var id))
        {
            MenuPrinter.PrintResult("ID doesn't exist!", MenuPrinter.FAIL_ICON);
            return;
        }
        
        var currentTask = await taskService.Get(id);
        
        MenuPrinter.PrintTasks([currentTask]);
        
        Console.Write("IsCompleted (Y/N): ");
        currentTask.IsCompleted = Console.ReadLine()?.ToUpper() == "Y";

        await taskService.Update(currentTask);
        
        MenuPrinter.PrintResult("Task status changed!");
        _currentState = AppState.MainMenu;
    }

    private async Task ShowDeleteTaskForm()
    {
        MenuPrinter.PrintTitle("Delete Task");
        
        Console.Write("Enter Task ID: ");
        if (!int.TryParse(Console.ReadLine(), out var id))
        {
            MenuPrinter.PrintResult("ID doesn't exist!", MenuPrinter.FAIL_ICON);
        }

        var taskToDelete = await taskService.Get(id);
            
        MenuPrinter.PrintTasks([taskToDelete]);

        if (ConfirmAction())
        {
            await taskService.Delete(id);
            MenuPrinter.PrintResult("Task deleted!");
        }
        
        _currentState = AppState.TasksList;
    }
}
