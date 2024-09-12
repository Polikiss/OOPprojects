namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemResultType;

public record FileSystemResult()
{
    public sealed record Success() : FileSystemResult;

    public sealed record Fail(string Message) : FileSystemResult;
}