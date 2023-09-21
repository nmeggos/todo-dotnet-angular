using System.Net;
using TodoTaskManagement.Domain.Interfaces;

namespace TodoTaskManagement.Domain.Exceptions;

public class InvalidTodoItemDueDateException : Exception, IHasHttpStatus
{
    public InvalidTodoItemDueDateException() : base("Due date cannot be in the past.")
    {
        
    }
    
    public InvalidTodoItemDueDateException(string message) : base(message)
    {
    }

    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}