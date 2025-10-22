namespace task_4_library_manger.Exceptions;

public class BookNotFoundException(Guid id) : NotFoundException($"The book with id: {id} was not found!");
