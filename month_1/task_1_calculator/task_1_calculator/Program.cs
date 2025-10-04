using System.Diagnostics;
using System.Text;
using static System.Single;

namespace task_1_calculator;

class Program
{
    static void Main(string[] args)
    {
        var mathResolver = new MathResolver();
        
        string key;
        do
        {
            try
            {
                MenuHandler.PrintMainMenu();

                var num1 = MenuHandler.GetNumberFromUser("Введите первое число:");
                mathResolver.AddNumber(num1);

                var op = MenuHandler.GetOperatorFromUser();
                mathResolver.AddOperator(op);
                
                var num2 = MenuHandler.GetNumberFromUser("Введите второе число:");
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
            
            MenuHandler.PrintRepeatMenu();
            key = Console.ReadLine() ?? "2";
            
        } while (key.Equals("1"));
    }
}