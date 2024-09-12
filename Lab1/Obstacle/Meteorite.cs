using Itmo.ObjectOrientedProgramming.Lab1.RouteMembers;
using Itmo.ObjectOrientedProgramming.Lab1.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacle;

public class Meteorite : INormalSpaceObstacle
{
    private int _obstacleMass = 3;
    public Meteorite()
    {
        ObstacleCount = 1;
    }

    public Meteorite(int obstacleCount)
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