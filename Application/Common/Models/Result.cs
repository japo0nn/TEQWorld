namespace Application.Common.Models;

public class Result
{
    public bool Succeeded { get; init; }
    public string[] Errors { get; init; }

    internal Result(bool succeeded, IEnumerable<string> errors)
    {
        Succeeded = succeeded;
        Errors = errors.ToArray();
    }

    public static Result Success()
    {
        return new Result(true, Array.Empty<string>());
    }

    public static Result Failure(IEnumerable<string> errors)
    {
        return new Result(false, errors);
    }
}

public class Result<TValue> : Result
{
    public TValue Value { get; }

    protected Result(bool succeeded, IEnumerable<string> errors, TValue value = default)
        : base(succeeded, errors)
    {
        Value = value;
    }

    public static Result<TValue> Success(TValue value)
    {
        return new Result<TValue>(true, Array.Empty<string>(), value);
    }

    public static new Result<TValue> Failure(IEnumerable<string> errors)
    {
        return new Result<TValue>(false, errors);
    }
}
