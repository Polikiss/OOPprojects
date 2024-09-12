namespace Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

public record ParseArgumentResult()
{
    public sealed record ParseArgumentSuccess() : ParseArgumentResult;

    public sealed record ParseArgumentFail(string Message) : ParseArgumentResult;
}