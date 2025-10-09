using System.Diagnostics;

namespace task_2_async;

class Program
{
    static async Task Main(string[] args)
    {
        string[] data = ["Файл 1", "Файл 2", "Файл 3"];

        var stopwatch = new Stopwatch();
        
        stopwatch.MeasureExec(() =>
        {
            foreach (var item in data)
            {
                Console.WriteLine(DataProcessor.ProcessData(item));
            }
        });
        Console.WriteLine();
        
        var tasks = data.Select(AsyncDataProcessor.ProcessDataAsync).ToArray();
        
        var result = stopwatch.MeasureExec(async () => await Task.WhenAll(tasks));

        foreach (var res in result.Result)
        {
            Console.WriteLine(res);
        }
    }
}