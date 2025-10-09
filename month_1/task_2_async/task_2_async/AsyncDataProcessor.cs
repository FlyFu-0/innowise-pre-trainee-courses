namespace task_2_async;

public class AsyncDataProcessor
{
    public static async Task<string> ProcessDataAsync(string dataName)
    {
        await Task.Delay(3000);
        
        return $"Обработка {dataName} завершена за 3 секунды";
    }
}