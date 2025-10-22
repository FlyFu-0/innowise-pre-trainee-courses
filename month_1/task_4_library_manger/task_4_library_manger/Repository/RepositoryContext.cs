using task_4_library_manger.Models;

namespace task_4_library_manger.Repository;

public class RepositoryContext
{
    public List<Book> Books { get; set; } = [];
    public List<Author> Authors { get; set; } = [];
    
    public void SeedData()
    {
        Authors.AddRange([
            new Author { Id = new Guid("8ee4dc1a-3b94-44a6-bd1b-ff23fc4d70d0"), Name = "Лев Толстой", DateOfBirth = DateTime.Today },
            new Author { Id = new Guid("3bb4602c-3a72-45d3-9786-78bfca23d984"), Name = "Фёдор Достоевский", DateOfBirth = DateTime.Today },
            new Author { Id = new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"), Name = "Антон Чехов", DateOfBirth = DateTime.Today },
            new Author { Id = new Guid("b2c3d4e5-f6a7-8901-bcde-f23456789012"), Name = "Николай Гоголь", DateOfBirth = DateTime.Today },
            new Author { Id = new Guid("c3d4e5f6-a7b8-9012-cdef-345678901234"), Name = "Александр Пушкин", DateOfBirth = DateTime.Today },
            new Author { Id = new Guid("d4e5f6a7-b8c9-0123-def0-456789012345"), Name = "Михаил Лермонтов", DateOfBirth = DateTime.Today }
        ]);

        Books.AddRange([
            // Лев Толстой
            new Book { Id = new Guid("7afe6552-9e5c-478d-84be-aeef79965f32"), Title = "Война и мир", AuthorId = new Guid("8ee4dc1a-3b94-44a6-bd1b-ff23fc4d70d0"), PublishedYear = new DateOnly(1869, 1, 1) },
            new Book { Id = Guid.NewGuid(), Title = "Юность", AuthorId = new Guid("8ee4dc1a-3b94-44a6-bd1b-ff23fc4d70d0"), PublishedYear = new DateOnly(1857, 1, 1) },
            new Book { Id = Guid.NewGuid(), Title = "Анна Каренина", AuthorId = new Guid("8ee4dc1a-3b94-44a6-bd1b-ff23fc4d70d0"), PublishedYear = new DateOnly(1877, 1, 1) },
            new Book { Id = Guid.NewGuid(), Title = "Воскресение", AuthorId = new Guid("8ee4dc1a-3b94-44a6-bd1b-ff23fc4d70d0"), PublishedYear = new DateOnly(1899, 1, 1) },

            // Фёдор Достоевский
            new Book { Id = new Guid("76d98093-1e0d-40f1-9e25-9d6066f0c283"), Title = "Преступление и наказание", AuthorId = new Guid("3bb4602c-3a72-45d3-9786-78bfca23d984"), PublishedYear = new DateOnly(1866, 1, 1) },
            new Book { Id = Guid.NewGuid(), Title = "Идиот", AuthorId = new Guid("3bb4602c-3a72-45d3-9786-78bfca23d984"), PublishedYear = new DateOnly(1869, 1, 1) },
            new Book { Id = Guid.NewGuid(), Title = "Братья Карамазовы", AuthorId = new Guid("3bb4602c-3a72-45d3-9786-78bfca23d984"), PublishedYear = new DateOnly(1880, 1, 1) },
            new Book { Id = Guid.NewGuid(), Title = "Бесы", AuthorId = new Guid("3bb4602c-3a72-45d3-9786-78bfca23d984"), PublishedYear = new DateOnly(1872, 1, 1) },

            // Антон Чехов
            new Book { Id = Guid.NewGuid(), Title = "Вишнёвый сад", AuthorId = new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"), PublishedYear = new DateOnly(1904, 1, 1) },
            new Book { Id = Guid.NewGuid(), Title = "Три сестры", AuthorId = new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"), PublishedYear = new DateOnly(1901, 1, 1) },
            new Book { Id = Guid.NewGuid(), Title = "Чайка", AuthorId = new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"), PublishedYear = new DateOnly(1896, 1, 1) },
            new Book { Id = Guid.NewGuid(), Title = "Дама с собачкой", AuthorId = new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"), PublishedYear = new DateOnly(1899, 1, 1) },

            // Николай Гоголь
            new Book { Id = Guid.NewGuid(), Title = "Мёртвые души", AuthorId = new Guid("b2c3d4e5-f6a7-8901-bcde-f23456789012"), PublishedYear = new DateOnly(1842, 1, 1) },
            new Book { Id = Guid.NewGuid(), Title = "Ревизор", AuthorId = new Guid("b2c3d4e5-f6a7-8901-bcde-f23456789012"), PublishedYear = new DateOnly(1836, 1, 1) },
            new Book { Id = Guid.NewGuid(), Title = "Вечера на хуторе близ Диканьки", AuthorId = new Guid("b2c3d4e5-f6a7-8901-bcde-f23456789012"), PublishedYear = new DateOnly(1831, 1, 1) },
            new Book { Id = Guid.NewGuid(), Title = "Тарас Бульба", AuthorId = new Guid("b2c3d4e5-f6a7-8901-bcde-f23456789012"), PublishedYear = new DateOnly(1835, 1, 1) },

            // Александр Пушкин
            new Book { Id = Guid.NewGuid(), Title = "Евгений Онегин", AuthorId = new Guid("c3d4e5f6-a7b8-9012-cdef-345678901234"), PublishedYear = new DateOnly(1833, 1, 1) },
            new Book { Id = Guid.NewGuid(), Title = "Капитанская дочка", AuthorId = new Guid("c3d4e5f6-a7b8-9012-cdef-345678901234"), PublishedYear = new DateOnly(1836, 1, 1) },
            new Book { Id = Guid.NewGuid(), Title = "Пиковая дама", AuthorId = new Guid("c3d4e5f6-a7b8-9012-cdef-345678901234"), PublishedYear = new DateOnly(1834, 1, 1) },
            new Book { Id = Guid.NewGuid(), Title = "Руслан и Людмила", AuthorId = new Guid("c3d4e5f6-a7b8-9012-cdef-345678901234"), PublishedYear = new DateOnly(1820, 1, 1) },

            // Михаил Лермонтов
            new Book { Id = Guid.NewGuid(), Title = "Герой нашего времени", AuthorId = new Guid("d4e5f6a7-b8c9-0123-def0-456789012345"), PublishedYear = new DateOnly(1840, 1, 1) },
            new Book { Id = Guid.NewGuid(), Title = "Мцыри", AuthorId = new Guid("d4e5f6a7-b8c9-0123-def0-456789012345"), PublishedYear = new DateOnly(1840, 1, 1) },
            new Book { Id = Guid.NewGuid(), Title = "Демон", AuthorId = new Guid("d4e5f6a7-b8c9-0123-def0-456789012345"), PublishedYear = new DateOnly(1842, 1, 1) },
            new Book { Id = Guid.NewGuid(), Title = "Бородино", AuthorId = new Guid("d4e5f6a7-b8c9-0123-def0-456789012345"), PublishedYear = new DateOnly(1837, 1, 1) }
        ]);
    }
    
    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}
