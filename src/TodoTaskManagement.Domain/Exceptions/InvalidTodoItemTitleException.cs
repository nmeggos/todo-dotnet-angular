using System.Net;
using TodoTaskManagement.Domain.Contracts;

namespace TodoTaskManagement.Domain.Exceptions;

public class InvalidTodoItemTitleException : Exception, IHasHttpStatus
{
    public InvalidTodoItemTitleException() : base("The provided TodoItem title is invalid.")
    {
        
    }
    
    public InvalidTodoItemTitleException(string message) : base(message)
    {
        
    }
    
    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}