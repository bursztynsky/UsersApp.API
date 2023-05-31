using System.Net;

namespace API.Controllers.Models;

public class Result
{
    public string Message { get; set; } = string.Empty;
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    public object Content { get; set; }

    public Result(object content)
    {
        Content = content;
    }
    
    public Result(string message, HttpStatusCode statusCode)
    {
        Message = message;
        StatusCode = statusCode;
    }
    
    public Result(string message, HttpStatusCode statusCode, object content)
    {
        Message = message;
        StatusCode = statusCode;
        Content = content;
    }
}