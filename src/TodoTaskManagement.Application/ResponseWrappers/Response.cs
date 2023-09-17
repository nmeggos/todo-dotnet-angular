namespace TodoTaskManagement.Application.ResponseWrappers;

public class Response<T>
{
    protected Response()
    {
    }
    
    public T? Data { get; private set; }
    public string Message { get; private set; }
    public List<string>? Errors { get; private set; }
    public bool Succeeded { get; private set; }

    public static Response<T> Success(string message)
    {
        return new Response<T>
        {
            Message = message,
            Succeeded = true
        };
    }

    public static Response<T> Success(T data, string message)
    {
        return new Response<T>
        {
            Data = data,
            Message = message,
            Succeeded = true
        };
    }
    
    public static Response<T> Failure(string message)
    {
        return new Response<T>
        {
            Message = message,
            Succeeded = false
        };
    }
    
    public static Response<T> Failure(string message, List<string> errors)
    {
        return new Response<T>
        {
            Message = message,
            Errors = errors,
            Succeeded = false
        };
    }
}