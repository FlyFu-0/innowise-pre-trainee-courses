namespace task_4_library_manger.Shared.RequestFeatures;

public class AuthorParameters : RequestParameters
{
    // public AuthorParameters() => OrderBy = "name";
    public DateTime? MinDateOfBirthday { get; set; }
    public DateTime? MaxDateOfBirthday { get; set; } = DateTime.Today;

    public bool ValidYearRange =>
        !MinDateOfBirthday.HasValue ||
        !MaxDateOfBirthday.HasValue ||
        MaxDateOfBirthday > MinDateOfBirthday;

    public string? SearchTerm { get; set; }
}
