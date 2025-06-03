using GuessingGameApp.Domain.Contracts;

namespace GuessingGameApp.Domain.Results.Service.WithData;

public class SuccessResultWithData<T> : ServiceResultWithData<T> where T : class
{
    public SuccessResultWithData(string message, T data) : base(true,message,data){}
}
