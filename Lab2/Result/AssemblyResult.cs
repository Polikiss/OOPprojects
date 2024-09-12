using Itmo.ObjectOrientedProgramming.Lab2.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Result;

public record AssemblyResult()
{
    public sealed record AssemblySuccess(IComputer Computer) : AssemblyResult;

    public sealed record Success() : AssemblyResult;
    public sealed record SuccessWithWarning(string Message) : AssemblyResult;

    public sealed record Fail() : AssemblyResult;

    public sealed record FailNotEnoughComponent() : AssemblyResult;
}