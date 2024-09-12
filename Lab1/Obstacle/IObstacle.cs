using Itmo.ObjectOrientedProgramming.Lab1.RouteMembers;
using Itmo.ObjectOrientedProgramming.Lab1.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacle;

public interface IObstacle
{
    public Result.DamageResult СauseDamage(IShip ship);
}