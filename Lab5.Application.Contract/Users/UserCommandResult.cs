namespace Lab5.Application.Contract.Users;

public record UserCommandResult()
{
    public sealed record Success() : UserCommandResult;

    public sealed record SuccessWithResult<T>(T Result) : UserCommandResult;
    public sealed record Fail() : UserCommandResult;
}