using Itmo.ObjectOrientedProgramming.Lab1.RouteMembers;
using Itmo.ObjectOrientedProgramming.Lab1.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacle;

public class CosmoWhale : INitriteObstacle
{
    private readonly int _obstacleMass = 40;
    public CosmoWhale()
    {
        ObstacleCount = 1;
    }

    public CosmoWhale(int obstacleCount)
    {
        ObstacleCount = obstacleCount;
    }

    public int ObstacleCount { get; }

    public Result.DamageResult СauseDamage(IShip ship)
    {
        if (ship.AntiNitriteRadiator is not null)
        {
            return new Result.DamageResult.DefenceSuccess();
        }

        Result.DamageResult damageResult = new Result.DamageResult.DefenceSuccess();
        for (int i = 0; i < ObstacleCount & damageResult is Result.DamageResult.DefenceSuccess; i++)
        {
            damageResult = ship.ShipDefense.TakeDamage(_obstacleMass);
        }

        return damageResult;
    }
}