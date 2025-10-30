using task_4_library_manger.Models;

namespace task_4_library_manger.Repository.Extensions;

public static class RepositoryBookExtensions
{
    public static IQueryable<Book> FilterBooks(this IQueryable<Book> books, DateOnly? minPublishYear = null, DateOnly? maxPublishYear = null)
    {
        var minDate = minPublishYear ?? DateOnly.FromDateTime(DateTime.MinValue);
        var maxDate = maxPublishYear ?? DateOnly.FromDateTime(DateTime.MaxValue);

        return books.Where(e => (e.PublishedYear >= minDate && e.PublishedYear <= maxDate));
    }

    public static IQueryable<Book> Search(this IQueryable<Book> books,
        string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return books;

        var lowerCaseTerms = searchTerm.Trim().ToLower();

        return books.Where(e => e.Title.ToLower().Contains(lowerCaseTerms));
    }
}
