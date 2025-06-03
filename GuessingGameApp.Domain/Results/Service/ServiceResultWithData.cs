using GuessingGameApp.Domain.Contracts;

namespace GuessingGameApp.Domain.Results.Service;

public class ServiceResultWithData<T> : IServiceResultWithData<T> where T : class
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public T Data { get; set; } = null!;
    public ServiceResultWithData(bool success, string message, T data)
    {
        Success = success;
        Message = message;
        Data = data;
    }
}