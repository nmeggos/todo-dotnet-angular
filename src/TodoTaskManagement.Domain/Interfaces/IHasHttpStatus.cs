using System.Net;

namespace TodoTaskManagement.Domain.Interfaces;

public interface IHasHttpStatus
{
    HttpStatusCode StatusCode { get; }
}