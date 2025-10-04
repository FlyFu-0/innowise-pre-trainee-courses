using System.Diagnostics;
using System.Text;
using static System.Single;

namespace task_1_calculator;

class Program
{
    static void Main(string[] args)
    {
        var mathResolver = new MathResolver();
        var menuHandler = new MenuHandler();
        
        string key;
        do
        {
            try
            {
                menuHandler.PrintMainMenu();

                var num1 = menuHandler.GetNumberFromUser("Введите первое число:");
                mathResolver.AddNumber(num1);

                var op = menuHandler.GetOperatorFromUser();
                mathResolver.AddOperator(op);
                
                var num2 = menuHandler.GetNumberFromUser("Введите второе число:");
                mathResolver.AddNumber(num2);
                
                var result = mathResolver.Calculate();
                Console.WriteLine($"\nРезультат: {num1} {op} {num2} = {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                mathResolver.Clear();
            }
            
            menuHandler.PrintRepeatMenu();
            key = Console.ReadLine() ?? "2";
            
        } while (key.Equals("1"));
    }
}