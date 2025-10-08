namespace Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

public abstract record Result<T>
{
    private bool IsSuccess => this is Success<T>;

    public bool IsFailure => !IsSuccess;

    public static Result<T> Success(T value)
    {
        return new Success<T>(value);
    }

    public static Result<T> Fail(IBusinessError error)
    {
        return new Failure<T>(error);
    }
}
