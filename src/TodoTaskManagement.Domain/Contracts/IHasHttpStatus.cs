using System.Net;

namespace TodoTaskManagement.Domain.Contracts;

public interface IHasHttpStatus
{
    HttpStatusCode StatusCode { get; }
}