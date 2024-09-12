using Itmo.ObjectOrientedProgramming.Lab1.RouteMembers;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engine;

public interface IPulseEngine
{
    public Result.RouteResult OvercomeEnvironment(int distance, int environmentalResistance);
}