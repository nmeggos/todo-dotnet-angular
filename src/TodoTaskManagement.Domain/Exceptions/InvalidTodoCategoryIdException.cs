using System.Net;
using TodoTaskManagement.Domain.Interfaces;

namespace TodoTaskManagement.Domain.Exceptions;

public class InvalidTodoCategoryIdException : Exception, IHasHttpStatus
{
    public InvalidTodoCategoryIdException(string message) : base(message)
    {
    }

    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}