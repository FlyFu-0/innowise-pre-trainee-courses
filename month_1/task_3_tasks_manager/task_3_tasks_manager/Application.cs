using task_3_tasks_manager.Contracts;
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

public class Application
{
    private readonly IRepository<TaskItem> _tasksRepository;
    private AppState _currentState = AppState.MainMenu;

    public Application(IRepository<TaskItem> tasksRepository)
    {
        _tasksRepository = tasksRepository;
    }

    public void Run()
    {
        while (_currentState != AppState.Exit)
        {
            RenderCurrentState();
            HandleInput();
        }
    }

    private void RenderCurrentState()
    {
        Console.Clear();
        
        switch (_currentState)
        {
            case AppState.MainMenu:
                MenuPrinter.PrintMainMenu();
                break;
            case AppState.TasksList:
                var tasks = _tasksRepository.GetAll();
                MenuPrinter.PrintTasks(tasks);
                MenuPrinter.PrintMenuBar();
                break;
            case AppState.CreateTask:
                ShowCreateTaskForm();
                break;
            case AppState.EditTask:
                ShowEditTaskForm();
                break;
            case AppState.DeleteTask:
                ShowDeleteTaskForm();
                break;
        }
    }

    private void HandleInput()
    {
        var input = Console.ReadLine();

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
    
    private void ShowCreateTaskForm()
    {
        MenuPrinter.PrintTitle("Create Task");
        
        var newTask = new TaskItem();
        
        Console.Write("Title: ");
        newTask.Title = Console.ReadLine() ?? newTask.Title;
        
        Console.Write("Description: ");
        newTask.Description = Console.ReadLine() ?? newTask.Description;
        
        Console.Write("IsCompleted (Y/N): ");
        newTask.IsCompleted = Console.ReadLine()?.ToUpper() == "Y";
        
        _tasksRepository.Add(newTask);
        
        MenuPrinter.PrintResult("Task Created!");
        _currentState = AppState.MainMenu;
    }
    
    private void ShowEditTaskForm()
    {
        MenuPrinter.PrintTitle("Change Task Status");
        
        Console.Write("Enter Task ID: ");
        if (!int.TryParse(Console.ReadLine(), out var id))
        {
            MenuPrinter.PrintResult("ID doesn't exist!", MenuPrinter.FAIL_ICON);
            return;
        }
        
        var currentTask = _tasksRepository.Get(id);
        
        MenuPrinter.PrintTasks([currentTask]);
        
        Console.Write("IsCompleted (Y/N): ");
        currentTask.IsCompleted = Console.ReadLine()?.ToUpper() == "Y";

        _tasksRepository.Update(currentTask);
        
        MenuPrinter.PrintResult("Task status changed!");
        _currentState = AppState.MainMenu;
    }

    private void ShowDeleteTaskForm()
    {
        MenuPrinter.PrintTitle("Delete Task");
        
        Console.Write("Enter Task ID: ");
        if (!int.TryParse(Console.ReadLine(), out var id))
        {
            MenuPrinter.PrintResult("ID doesn't exist!", MenuPrinter.FAIL_ICON);
        }

        var taskToDelete = _tasksRepository.Get(id);
            
        MenuPrinter.PrintTasks([taskToDelete]);

        if (ConfirmAction())
        {
            _tasksRepository.Delete(id);
            MenuPrinter.PrintResult("Task deleted!");
        }
        
        _currentState = AppState.TasksList;
    }
}