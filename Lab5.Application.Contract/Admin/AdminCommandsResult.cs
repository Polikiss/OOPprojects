namespace Lab5.Application.Contract.Admin;

public record AdminCommandsResult()
{
    public sealed record Success() : AdminCommandsResult;
    public sealed record Fail() : AdminCommandsResult;
}