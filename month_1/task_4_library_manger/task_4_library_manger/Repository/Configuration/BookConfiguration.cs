using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using task_4_library_manger.Models;

namespace task_4_library_manger.Repository.Configuration;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasData(
            // Лев Толстой
new Book { Id = new Guid("7afe6552-9e5c-478d-84be-aeef79965f32"), Title = "Война и мир", AuthorId = new Guid("8ee4dc1a-3b94-44a6-bd1b-ff23fc4d70d0"), PublishedYear = new DateOnly(1869, 1, 1) },
new Book { Id = new Guid("1a2b3c4d-5e6f-7890-abcd-ef1234567890"), Title = "Юность", AuthorId = new Guid("8ee4dc1a-3b94-44a6-bd1b-ff23fc4d70d0"), PublishedYear = new DateOnly(1857, 1, 1) },
new Book { Id = new Guid("2b3c4d5e-6f7a-8901-bcde-f23456789012"), Title = "Анна Каренина", AuthorId = new Guid("8ee4dc1a-3b94-44a6-bd1b-ff23fc4d70d0"), PublishedYear = new DateOnly(1877, 1, 1) },
new Book { Id = new Guid("3c4d5e6f-7a8b-9012-cdef-345678901234"), Title = "Воскресение", AuthorId = new Guid("8ee4dc1a-3b94-44a6-bd1b-ff23fc4d70d0"), PublishedYear = new DateOnly(1899, 1, 1) },

// Фёдор Достоевский
new Book { Id = new Guid("76d98093-1e0d-40f1-9e25-9d6066f0c283"), Title = "Преступление и наказание", AuthorId = new Guid("3bb4602c-3a72-45d3-9786-78bfca23d984"), PublishedYear = new DateOnly(1866, 1, 1) },
new Book { Id = new Guid("4d5e6f7a-8b9c-0123-def0-456789012345"), Title = "Идиот", AuthorId = new Guid("3bb4602c-3a72-45d3-9786-78bfca23d984"), PublishedYear = new DateOnly(1869, 1, 1) },
new Book { Id = new Guid("5e6f7a8b-9c0d-1234-ef01-567890123456"), Title = "Братья Карамазовы", AuthorId = new Guid("3bb4602c-3a72-45d3-9786-78bfca23d984"), PublishedYear = new DateOnly(1880, 1, 1) },
new Book { Id = new Guid("6f7a8b9c-0d1e-2345-f012-678901234567"), Title = "Бесы", AuthorId = new Guid("3bb4602c-3a72-45d3-9786-78bfca23d984"), PublishedYear = new DateOnly(1872, 1, 1) },

// Антон Чехов
new Book { Id = new Guid("7a8b9c0d-1e2f-3456-0123-789012345678"), Title = "Вишнёвый сад", AuthorId = new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"), PublishedYear = new DateOnly(1904, 1, 1) },
new Book { Id = new Guid("8b9c0d1e-2f3a-4567-1234-890123456789"), Title = "Три сестры", AuthorId = new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"), PublishedYear = new DateOnly(1901, 1, 1) },
new Book { Id = new Guid("9c0d1e2f-3a4b-5678-2345-901234567890"), Title = "Чайка", AuthorId = new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"), PublishedYear = new DateOnly(1896, 1, 1) },
new Book { Id = new Guid("0d1e2f3a-4b5c-6789-3456-012345678901"), Title = "Дама с собачкой", AuthorId = new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"), PublishedYear = new DateOnly(1899, 1, 1) },

// Николай Гоголь
new Book { Id = new Guid("1e2f3a4b-5c6d-7890-4567-123456789012"), Title = "Мёртвые души", AuthorId = new Guid("b2c3d4e5-f6a7-8901-bcde-f23456789012"), PublishedYear = new DateOnly(1842, 1, 1) },
new Book { Id = new Guid("2f3a4b5c-6d7e-8901-5678-234567890123"), Title = "Ревизор", AuthorId = new Guid("b2c3d4e5-f6a7-8901-bcde-f23456789012"), PublishedYear = new DateOnly(1836, 1, 1) },
new Book { Id = new Guid("3a4b5c6d-7e8f-9012-6789-345678901234"), Title = "Вечера на хуторе близ Диканьки", AuthorId = new Guid("b2c3d4e5-f6a7-8901-bcde-f23456789012"), PublishedYear = new DateOnly(1831, 1, 1) },
new Book { Id = new Guid("4b5c6d7e-8f9a-0123-7890-456789012345"), Title = "Тарас Бульба", AuthorId = new Guid("b2c3d4e5-f6a7-8901-bcde-f23456789012"), PublishedYear = new DateOnly(1835, 1, 1) },

// Александр Пушкин
new Book { Id = new Guid("5c6d7e8f-9a0b-1234-8901-567890123456"), Title = "Евгений Онегин", AuthorId = new Guid("c3d4e5f6-a7b8-9012-cdef-345678901234"), PublishedYear = new DateOnly(1833, 1, 1) },
new Book { Id = new Guid("6d7e8f9a-0b1c-2345-9012-678901234567"), Title = "Капитанская дочка", AuthorId = new Guid("c3d4e5f6-a7b8-9012-cdef-345678901234"), PublishedYear = new DateOnly(1836, 1, 1) },
new Book { Id = new Guid("7e8f9a0b-1c2d-3456-0123-789012345678"), Title = "Пиковая дама", AuthorId = new Guid("c3d4e5f6-a7b8-9012-cdef-345678901234"), PublishedYear = new DateOnly(1834, 1, 1) },
new Book { Id = new Guid("8f9a0b1c-2d3e-4567-1234-890123456789"), Title = "Руслан и Людмила", AuthorId = new Guid("c3d4e5f6-a7b8-9012-cdef-345678901234"), PublishedYear = new DateOnly(1820, 1, 1) },

// Михаил Лермонтов
new Book { Id = new Guid("9a0b1c2d-3e4f-5678-2345-901234567890"), Title = "Герой нашего времени", AuthorId = new Guid("d4e5f6a7-b8c9-0123-def0-456789012345"), PublishedYear = new DateOnly(1840, 1, 1) },
new Book { Id = new Guid("0b1c2d3e-4f5a-6789-3456-012345678901"), Title = "Мцыри", AuthorId = new Guid("d4e5f6a7-b8c9-0123-def0-456789012345"), PublishedYear = new DateOnly(1840, 1, 1) },
new Book { Id = new Guid("1c2d3e4f-5a6b-7890-4567-123456789012"), Title = "Демон", AuthorId = new Guid("d4e5f6a7-b8c9-0123-def0-456789012345"), PublishedYear = new DateOnly(1842, 1, 1) },
new Book { Id = new Guid("2d3e4f5a-6b7c-8901-5678-234567890123"), Title = "Бородино", AuthorId = new Guid("d4e5f6a7-b8c9-0123-def0-456789012345"), PublishedYear = new DateOnly(1837, 1, 1) }
        );
    }
}
