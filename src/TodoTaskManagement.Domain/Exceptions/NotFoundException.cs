using System.Net;
using TodoTaskManagement.Domain.Interfaces;

namespace TodoTaskManagement.Domain.Exceptions;

public class NotFoundException : Exception, IHasHttpStatus
{
    public NotFoundException()
    {
        
    }

    public NotFoundException(string message) : base(message)
    {
        
    }

    public NotFoundException(Type type, string id) : base($"Entity of type {type.Name} with id {id} was not found")
    {
        
    }

    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;
}