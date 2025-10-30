using task_4_library_manger.Entities.Models;

namespace task_4_library_manger.Repository.Extensions;

public static class RepositoryAuthorExtensions
{
    public static IQueryable<Author> FilterAuthors(this IQueryable<Author> authors, DateTime? minDateOfBirth = null, DateTime? maxDateOfBirth = null)
    {
        var minDate = minDateOfBirth ?? DateTime.MinValue;
        var maxDate = maxDateOfBirth ?? DateTime.MaxValue;

        return authors.Where(e => (e.DateOfBirth >= minDate && e.DateOfBirth <= maxDate));
    }

    public static IQueryable<Author> Search(this IQueryable<Author> authors,
        string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return authors;

        var lowerCaseTerms = searchTerm.Trim().ToLower();

        return authors.Where(e => e.Name.ToLower().Contains(lowerCaseTerms));
    }
}
