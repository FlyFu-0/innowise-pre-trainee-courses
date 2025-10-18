namespace task_3_tasks_manager.Helpers;

public static  class ConsoleInputValidator
{
    public static string GetRequiredString(string fieldName, int maxLength = 100)
    {
        while (true)
        {
            Console.Write($"{fieldName}: ");
            var input = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine($"❌ {fieldName} cannot be empty.");
                continue;
            }

            if (input.Length > maxLength)
            {
                Console.WriteLine($"❌ {fieldName} cannot exceed {maxLength} characters.");
                continue;
            }

            return input;
        }
    }

    public static bool GetYesNo(string fieldName)
    {
        while (true)
        {
            Console.Write($"{fieldName} (Y/N): ");
            var input = Console.ReadLine()?.ToUpper();

            if (input == "Y") return true;
            if (input == "N") return false;
            if (input == "") return false;

            Console.WriteLine("❌ Please enter Y or N.");
        }
    }
}
