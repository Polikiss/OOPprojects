using Itmo.ObjectOrientedProgramming.Lab1.RouteMembers;
using Itmo.ObjectOrientedProgramming.Lab1.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacle;

public class SmallAsteroid : INormalSpaceObstacle
{
    private readonly int _obstacleMass = 1;
    public SmallAsteroid()
    {
        ObstacleCount = 1;
    }

    public SmallAsteroid(int obstacleCount)
    {
        ObstacleCount = obstacleCount;
    }

    public int ObstacleCount { get; }

    public Result.DamageResult СauseDamage(IShip ship)
    {
        Result.DamageResult damageResult = new Result.DamageResult.DefenceSuccess();
        for (int i = 0; i < ObstacleCount & damageResult is Result.DamageResult.DefenceSuccess; i++)
        {
            damageResult = ship.ShipDefense.TakeDamage(_obstacleMass);
        }

        return damageResult;
    }
}