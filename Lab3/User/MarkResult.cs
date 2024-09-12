namespace Itmo.ObjectOrientedProgramming.Lab3.User;

public record MarkResult()
{
    public sealed record SuccessMark() : MarkResult;

    public sealed record AlreadyRead() : MarkResult;
}