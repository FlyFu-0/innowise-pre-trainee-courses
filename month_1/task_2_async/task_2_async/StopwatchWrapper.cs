using System.Diagnostics;
using System.Text;

namespace task_2_async;

public static class StopwatchWrapper
{
    public static void MeasureExec(this Stopwatch stopwatch, Action func)
    {
        stopwatch.Reset();
        Console.WriteLine($"Замер времени sync обработки начат: {stopwatch.Elapsed}");
        
        stopwatch.Start();

        func();
        
        stopwatch.Stop();
        Console.WriteLine($"Замер времени sync обработки закончен: {stopwatch.Elapsed}");
    }
    
    public static async Task MeasureExec(this Stopwatch stopwatch, Func<Task> func)
    {
        stopwatch.Reset();
        Console.WriteLine($"Замер времени async обработки начат: {stopwatch.Elapsed}");
        
        stopwatch.Start();

        await func();
        
        stopwatch.Stop();
        Console.WriteLine($"Замер времени async обработки закончен: {stopwatch.Elapsed}");
    }
}