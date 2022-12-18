namespace Application.Common.Model;

public class ExceptionModel
{
    public ExceptionModel(object message, int statusCode = 500)
    {
        StatusCode = statusCode;
        Message = message;
    }

    public int StatusCode { get; set; }
    public object Message { get; set; }
}

