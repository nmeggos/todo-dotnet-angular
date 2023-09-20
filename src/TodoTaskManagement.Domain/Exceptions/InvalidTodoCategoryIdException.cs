namespace TodoTaskManagement.Domain.Exceptions;

public class InvalidTodoCategoryIdException : Exception
{
    public InvalidTodoCategoryIdException(string message) : base(message)
    {
    }
}