using System.Diagnostics;
using static System.Single;

namespace task_1_calculator;

class Program
{
    static void Main(string[] args)
    {
        var key = "0";
        do
        {
            Console.Clear();
            
            Console.WriteLine("Введите первое число: ");
            TryParse(Console.ReadLine(), out var num1);

            Console.WriteLine("Выберите оператор: ");
            Console.WriteLine("1. +\n2. -\n3. *\n4. /\n");
            var mathOperator = Console.ReadLine();

            Console.WriteLine("Введите второе число: ");
            TryParse(Console.ReadLine(), out var num2);

            float result = 0;
            switch (mathOperator)
            {
                case "1":
                case "+":
                    result = num1 + num2;
                    break;
                case "2":
                case "-":
                    result = num1 - num2;
                    break;
                case "3":
                case "*":
                    result = num1 * num2;
                    break;
                case "4":
                case "/":
                    result = num1 / num2;
                    break;
            }

            Console.WriteLine($"Ответ: {num1} {mathOperator} {num2} = {result}");

            Console.WriteLine();
            Console.WriteLine("1. Выполнить новую операцию");
            Console.WriteLine("2. Выйти");
            key = Console.ReadLine();
        } while (key.Equals("1"));
    }
}