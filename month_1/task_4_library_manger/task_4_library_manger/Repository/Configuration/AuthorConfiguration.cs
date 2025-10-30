using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using task_4_library_manger.Entities.Models;

namespace task_4_library_manger.Repository.Configuration;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasData(
            new Author { Id = new Guid("8ee4dc1a-3b94-44a6-bd1b-ff23fc4d70d0"), Name = "Лев Толстой", DateOfBirth = new DateTime(1828, 9, 9) },
            new Author { Id = new Guid("3bb4602c-3a72-45d3-9786-78bfca23d984"), Name = "Фёдор Достоевский", DateOfBirth = new DateTime(1821, 11, 11) },
            new Author { Id = new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"), Name = "Антон Чехов", DateOfBirth = new DateTime(1860, 1, 29) },
            new Author { Id = new Guid("b2c3d4e5-f6a7-8901-bcde-f23456789012"), Name = "Николай Гоголь", DateOfBirth = new DateTime(1809, 4, 1) },
            new Author { Id = new Guid("c3d4e5f6-a7b8-9012-cdef-345678901234"), Name = "Александр Пушкин", DateOfBirth = new DateTime(1799, 6, 6) },
            new Author { Id = new Guid("d4e5f6a7-b8c9-0123-def0-456789012345"), Name = "Михаил Лермонтов", DateOfBirth = new DateTime(1814, 10, 15) }
        );
    }
}
