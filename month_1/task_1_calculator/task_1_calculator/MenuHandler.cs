namespace task_1_calculator;

public class MenuHandler
{
    public void PrintMainMenu()
    {
        Console.Clear();
        Console.WriteLine("=== КАЛЬКУЛЯТОР ===");
        Console.WriteLine();
    }

    public void PrintRepeatMenu()
    {
        Console.WriteLine("\n1. Выполнить новую операцию");
        Console.WriteLine("2. Выйти");
        Console.Write("Выберите действие: ");
    }

    public float GetNumberFromUser(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (float.TryParse(Console.ReadLine(), out var number))
            {
                return number;
            }
            Console.WriteLine("Ошибка: введите корректное число!");
        }
    }

    public string GetOperatorFromUser()
    {
        while (true)
        {
            Console.Write("Введите оператор (+, -, *, /): ");
            string op = Console.ReadLine()?.Trim() ?? "";
            
            if (MathResolver.IsOperatorValid(op))
            {
                return op;
            }
            
            Console.WriteLine("Ошибка: введите один из допустимых операторов (+, -, *, /)!");
        }
    }
}