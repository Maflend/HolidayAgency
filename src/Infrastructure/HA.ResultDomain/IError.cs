namespace HA.ResultDomain;

public interface IError
{
    string Message { get; }
}

public abstract class ErrorBase : IError
{
    public string Message { get; }
}

public abstract class ErrorBase<TData> : ErrorBase
{
    public string Message { get; }

    public IEnumerable<TData> Reson { get; set; }
}