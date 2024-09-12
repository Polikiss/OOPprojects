using Itmo.ObjectOrientedProgramming.Lab1.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteMembers;

public interface IRoute
{
    public Result GoRoute(IShip ship);
}