namespace task_4_library_manger.Exceptions;

public class AuthorNotFoundException(Guid id) : NotFoundException($"The author with id: {id} was not found.");
