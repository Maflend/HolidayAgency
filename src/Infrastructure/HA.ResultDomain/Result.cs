namespace HA.ResultDomain;

public class Result<TValue> : ResultBase
{
    internal Result(TValue value)
    {
        Value = value;
        _isSuccess = true;
    }

    internal Result(IError error)
    {
        _isSuccess = false;
        Error = error;
    }

    public TValue? Value { get; set; }

    public static Result<TValue> Fail(IError error)
    {
        return new Result<TValue>(error);
    }

    public static Result<TValue> Success(TValue success)
    {
        return new Result<TValue>(success);
    }

    public static implicit operator Result<TValue> (TValue value)
    {
        return new Result<TValue>(value);
    }
}

public abstract class ResultBase
{
    protected bool _isSuccess;

    public bool IsSuccess => _isSuccess;
    public bool IsFailure => !_isSuccess;

    public IError? Error { get; set; }
}
