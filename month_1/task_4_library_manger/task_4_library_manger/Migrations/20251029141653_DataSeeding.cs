using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace task_4_library_manger.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "DateOfBirth", "Name" },
                values: new object[,]
                {
                    { new Guid("3bb4602c-3a72-45d3-9786-78bfca23d984"), new DateTime(1821, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Фёдор Достоевский" },
                    { new Guid("8ee4dc1a-3b94-44a6-bd1b-ff23fc4d70d0"), new DateTime(1828, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Лев Толстой" },
                    { new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"), new DateTime(1860, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон Чехов" },
                    { new Guid("b2c3d4e5-f6a7-8901-bcde-f23456789012"), new DateTime(1809, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Николай Гоголь" },
                    { new Guid("c3d4e5f6-a7b8-9012-cdef-345678901234"), new DateTime(1799, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Александр Пушкин" },
                    { new Guid("d4e5f6a7-b8c9-0123-def0-456789012345"), new DateTime(1814, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Михаил Лермонтов" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "PublishedYear", "Title" },
                values: new object[,]
                {
                    { new Guid("0b1c2d3e-4f5a-6789-3456-012345678901"), new Guid("d4e5f6a7-b8c9-0123-def0-456789012345"), new DateOnly(1840, 1, 1), "Мцыри" },
                    { new Guid("0d1e2f3a-4b5c-6789-3456-012345678901"), new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"), new DateOnly(1899, 1, 1), "Дама с собачкой" },
                    { new Guid("1a2b3c4d-5e6f-7890-abcd-ef1234567890"), new Guid("8ee4dc1a-3b94-44a6-bd1b-ff23fc4d70d0"), new DateOnly(1857, 1, 1), "Юность" },
                    { new Guid("1c2d3e4f-5a6b-7890-4567-123456789012"), new Guid("d4e5f6a7-b8c9-0123-def0-456789012345"), new DateOnly(1842, 1, 1), "Демон" },
                    { new Guid("1e2f3a4b-5c6d-7890-4567-123456789012"), new Guid("b2c3d4e5-f6a7-8901-bcde-f23456789012"), new DateOnly(1842, 1, 1), "Мёртвые души" },
                    { new Guid("2b3c4d5e-6f7a-8901-bcde-f23456789012"), new Guid("8ee4dc1a-3b94-44a6-bd1b-ff23fc4d70d0"), new DateOnly(1877, 1, 1), "Анна Каренина" },
                    { new Guid("2d3e4f5a-6b7c-8901-5678-234567890123"), new Guid("d4e5f6a7-b8c9-0123-def0-456789012345"), new DateOnly(1837, 1, 1), "Бородино" },
                    { new Guid("2f3a4b5c-6d7e-8901-5678-234567890123"), new Guid("b2c3d4e5-f6a7-8901-bcde-f23456789012"), new DateOnly(1836, 1, 1), "Ревизор" },
                    { new Guid("3a4b5c6d-7e8f-9012-6789-345678901234"), new Guid("b2c3d4e5-f6a7-8901-bcde-f23456789012"), new DateOnly(1831, 1, 1), "Вечера на хуторе близ Диканьки" },
                    { new Guid("3c4d5e6f-7a8b-9012-cdef-345678901234"), new Guid("8ee4dc1a-3b94-44a6-bd1b-ff23fc4d70d0"), new DateOnly(1899, 1, 1), "Воскресение" },
                    { new Guid("4b5c6d7e-8f9a-0123-7890-456789012345"), new Guid("b2c3d4e5-f6a7-8901-bcde-f23456789012"), new DateOnly(1835, 1, 1), "Тарас Бульба" },
                    { new Guid("4d5e6f7a-8b9c-0123-def0-456789012345"), new Guid("3bb4602c-3a72-45d3-9786-78bfca23d984"), new DateOnly(1869, 1, 1), "Идиот" },
                    { new Guid("5c6d7e8f-9a0b-1234-8901-567890123456"), new Guid("c3d4e5f6-a7b8-9012-cdef-345678901234"), new DateOnly(1833, 1, 1), "Евгений Онегин" },
                    { new Guid("5e6f7a8b-9c0d-1234-ef01-567890123456"), new Guid("3bb4602c-3a72-45d3-9786-78bfca23d984"), new DateOnly(1880, 1, 1), "Братья Карамазовы" },
                    { new Guid("6d7e8f9a-0b1c-2345-9012-678901234567"), new Guid("c3d4e5f6-a7b8-9012-cdef-345678901234"), new DateOnly(1836, 1, 1), "Капитанская дочка" },
                    { new Guid("6f7a8b9c-0d1e-2345-f012-678901234567"), new Guid("3bb4602c-3a72-45d3-9786-78bfca23d984"), new DateOnly(1872, 1, 1), "Бесы" },
                    { new Guid("76d98093-1e0d-40f1-9e25-9d6066f0c283"), new Guid("3bb4602c-3a72-45d3-9786-78bfca23d984"), new DateOnly(1866, 1, 1), "Преступление и наказание" },
                    { new Guid("7a8b9c0d-1e2f-3456-0123-789012345678"), new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"), new DateOnly(1904, 1, 1), "Вишнёвый сад" },
                    { new Guid("7afe6552-9e5c-478d-84be-aeef79965f32"), new Guid("8ee4dc1a-3b94-44a6-bd1b-ff23fc4d70d0"), new DateOnly(1869, 1, 1), "Война и мир" },
                    { new Guid("7e8f9a0b-1c2d-3456-0123-789012345678"), new Guid("c3d4e5f6-a7b8-9012-cdef-345678901234"), new DateOnly(1834, 1, 1), "Пиковая дама" },
                    { new Guid("8b9c0d1e-2f3a-4567-1234-890123456789"), new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"), new DateOnly(1901, 1, 1), "Три сестры" },
                    { new Guid("8f9a0b1c-2d3e-4567-1234-890123456789"), new Guid("c3d4e5f6-a7b8-9012-cdef-345678901234"), new DateOnly(1820, 1, 1), "Руслан и Людмила" },
                    { new Guid("9a0b1c2d-3e4f-5678-2345-901234567890"), new Guid("d4e5f6a7-b8c9-0123-def0-456789012345"), new DateOnly(1840, 1, 1), "Герой нашего времени" },
                    { new Guid("9c0d1e2f-3a4b-5678-2345-901234567890"), new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"), new DateOnly(1896, 1, 1), "Чайка" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("0b1c2d3e-4f5a-6789-3456-012345678901"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("0d1e2f3a-4b5c-6789-3456-012345678901"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1a2b3c4d-5e6f-7890-abcd-ef1234567890"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1c2d3e4f-5a6b-7890-4567-123456789012"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1e2f3a4b-5c6d-7890-4567-123456789012"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("2b3c4d5e-6f7a-8901-bcde-f23456789012"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("2d3e4f5a-6b7c-8901-5678-234567890123"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("2f3a4b5c-6d7e-8901-5678-234567890123"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("3a4b5c6d-7e8f-9012-6789-345678901234"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("3c4d5e6f-7a8b-9012-cdef-345678901234"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("4b5c6d7e-8f9a-0123-7890-456789012345"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("4d5e6f7a-8b9c-0123-def0-456789012345"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5c6d7e8f-9a0b-1234-8901-567890123456"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5e6f7a8b-9c0d-1234-ef01-567890123456"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("6d7e8f9a-0b1c-2345-9012-678901234567"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("6f7a8b9c-0d1e-2345-f012-678901234567"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("76d98093-1e0d-40f1-9e25-9d6066f0c283"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("7a8b9c0d-1e2f-3456-0123-789012345678"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("7afe6552-9e5c-478d-84be-aeef79965f32"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("7e8f9a0b-1c2d-3456-0123-789012345678"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("8b9c0d1e-2f3a-4567-1234-890123456789"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("8f9a0b1c-2d3e-4567-1234-890123456789"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("9a0b1c2d-3e4f-5678-2345-901234567890"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("9c0d1e2f-3a4b-5678-2345-901234567890"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("3bb4602c-3a72-45d3-9786-78bfca23d984"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("8ee4dc1a-3b94-44a6-bd1b-ff23fc4d70d0"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a7-8901-bcde-f23456789012"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("c3d4e5f6-a7b8-9012-cdef-345678901234"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("d4e5f6a7-b8c9-0123-def0-456789012345"));
        }
    }
}
