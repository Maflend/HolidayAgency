namespace HA.Application.Common.Results;

public class Result<TData> : ResultBase
{
    public Result() { }

    internal Result(TData value)
    {
        Data = value;
        _isSuccess = true;
    }

    internal Result(IError error)
    {
        _isSuccess = false;
        Error = error;
    }

    public TData? Data { get; set; }

    public static Result<TData> Fail(IError error)
    {
        return new Result<TData>(error);
    }

    public static Result<TData> Success(TData success)
    {
        return new Result<TData>(success);
    }

    public static implicit operator Result<TData>(TData value)
    {
        return new Result<TData>(value);
    }
}

public abstract class ResultBase : IResultBase
{
    protected bool _isSuccess;

    public bool IsSuccess => _isSuccess;
    public bool IsFailure => !_isSuccess;

    public IError? Error { get; set; }
}

public interface IResultBase
{
    public bool IsSuccess { get; }
    public IError? Error { get; set; }
}