using task_4_library_manger.Models;

namespace task_4_library_manger.Repository;

public class RepositoryContext
{
    public List<Book> Books { get; set; } = [];
    public List<Author> Authors { get; set; } = [];
    
    public void SeedData()
    {
        Authors.AddRange([
            new Author { Id = 1, Name = "Лев Толстой" },
            new Author { Id = 2, Name = "Фёдор Достоевский" }
        ]);

        Books.AddRange([
            new Book { Id = 1, Title = "Война и мир", AuthorId = 1 },
            new Book { Id = 2, Title = "Преступление и наказание", AuthorId = 2 }
        ]);
    }
    
    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}