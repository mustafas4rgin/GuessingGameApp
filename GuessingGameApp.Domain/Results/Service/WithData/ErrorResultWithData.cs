using GuessingGameApp.Domain.Contracts;
using GuessingGameApp.Domain.Results.Service;

namespace GuessingGameApp.Domain.Results.Service.WithData;

public class ErrorResultWithData<T> : ServiceResultWithData<T> where T : class
{
    public ErrorResultWithData(string message) : base(false,message,default!) {}
}