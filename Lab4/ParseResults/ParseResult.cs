using Itmo.ObjectOrientedProgramming.Lab4.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParseResults;

public record ParseResult()
{
    public sealed record Success(ICommand Command) : ParseResult;

    public sealed record FlagSuccess<T>(T Mode) : ParseResult;

    public sealed record Fail(string FailReason) : ParseResult;
}