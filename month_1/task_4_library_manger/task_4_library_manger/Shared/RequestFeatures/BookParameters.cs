namespace task_4_library_manger.Shared.RequestFeatures;

public class BookParameters : RequestParameters
{
    // public BookParameters() => OrderBy = "title";
    public DateOnly? MinPublishYear { get; set; }
    public DateOnly? MaxPublishYear { get; set; } = DateOnly.FromDateTime(DateTime.Today);

    public bool ValidYearRange =>
        !MinPublishYear.HasValue ||
        !MaxPublishYear.HasValue ||
        MaxPublishYear > MinPublishYear;

    public string? SearchTerm { get; set; }
}
