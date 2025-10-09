namespace task_2_async;

public class AsyncDataProcessor
{
    public static async Task ProcessDataAsync(string dataName)
    {
        await Task.Delay(3000);
    }
}