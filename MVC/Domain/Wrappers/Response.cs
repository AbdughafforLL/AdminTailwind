using System.Net;
namespace MVC.Domain.Wrappers;
public class Response<T>
{
    public int StatusCode { get; set; }
    public List<string>? Errors { get; set; }
    public T? Data { get; set; }

    public Response(T data)
    {
        StatusCode = (int)HttpStatusCode.OK;
        Data = data;
    }
    public Response(HttpStatusCode code , string message)
    {
        Errors = new List<string>() { message };
        StatusCode = (int)code;
    }

    public Response(HttpStatusCode code ,List<string> errors)
    {
        StatusCode = (int)code;
        Errors = errors;
    }
}