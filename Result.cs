namespace ShapeValidator;

/// <summary>
/// Represents the outcome of an operation that can either succeed with a value
/// or fail with a descriptive error message.
/// </summary>
public sealed class Result<T>
{
    public bool IsSuccess { get; }

    public T Value => IsSuccess
        ? _value
        : throw new InvalidOperationException("Cannot access Value of a failed result.");

    public string? Error { get; }

    private readonly T _value;

    /// <summary>
    /// The private constructor enforces the invariant that a successful result always has a value.
    /// </summary>
    /// <param name="value">Value of successful result</param>
    private Result(T value)
    {
        IsSuccess = true;
        _value = value;
        Error = null;
    }

    /// <summary>
    /// The private constructor enforces the invariant that the value of a failed result should not be accessed.
    /// </summary>
    /// <param name="error">Error message</param>
    private Result(string error)
    {
        IsSuccess = false;
        _value = default!;
        Error = error;
    }

    /// <summary>
    /// Creates a successful result containing the specified value.
    /// </summary>
    /// <param name="value">The value to be wrapped in a successful result.</param>
    /// <returns> Successful operation with the specified value.</returns>
    public static Result<T> Success(T value)
    {
        return new Result<T>(value);
    }

    /// <summary>
    /// Creates a failed result with the specified error message.
    /// </summary>
    /// <param name="error">The error message that describes the reason for the failure. Cannot be null or empty.</param>
    /// <returns> Failed operation with the provided error message.</returns>
    public static Result<T> Failure(string error)
    {
        return new Result<T>(error);
    }
}
