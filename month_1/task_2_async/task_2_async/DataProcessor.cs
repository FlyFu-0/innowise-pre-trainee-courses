namespace task_2_async;

public class DataProcessor
{
    public static string ProcessData(string dataName)
    {
        Thread.Sleep(3000);
        
        return $"Обработка {dataName} завершена за 3 секунды";
    }
}