using Itmo.ObjectOrientedProgramming.Lab1.RouteMembers;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engine;

public interface IJumpEngine
{
    public Result.RouteResult OvercomeEnvironment(int distance);
}