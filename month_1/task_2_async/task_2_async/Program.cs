namespace task_2_async;

class Program
{
    static async Task Main(string[] args)
    {
        string[] data = ["Файл 1", "Файл 2", "Файл 3"];

        foreach (var item in data)
        {
            Console.WriteLine(ProcessData(item));
        }

        var tasks = data.Select(ProcessDataAsync).ToArray();

        var results = await Task.WhenAll(tasks);
        
        Console.WriteLine();
        foreach (var item in results)
        {
            Console.WriteLine(item);
        }
    }

    public static string ProcessData(string dataName)
    {
        Thread.Sleep(3000);

        return $"Обработка {dataName} завершена за 3 секунды";
    }

    public static async Task<string> ProcessDataAsync(string dataName)
    {
        await Task.Delay(3000);

        return $"Обработка {dataName} завершена за 3 секунды";
    }
}