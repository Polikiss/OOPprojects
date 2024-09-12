using Itmo.ObjectOrientedProgramming.Lab1.RouteMembers;
using Itmo.ObjectOrientedProgramming.Lab1.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public interface IEnvironment
{
    public Result OvercomeEnvironment(IShip ship);
}