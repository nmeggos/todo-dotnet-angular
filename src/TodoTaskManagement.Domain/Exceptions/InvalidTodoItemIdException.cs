using System.Net;
using TodoTaskManagement.Domain.Contracts;

namespace TodoTaskManagement.Domain.Exceptions;

public class InvalidTodoItemIdException : Exception, IHasHttpStatus
{
    public InvalidTodoItemIdException(string value) : base($"The provided TodoItemId value '{value}' is invalid.")
    {
        
    }

    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}